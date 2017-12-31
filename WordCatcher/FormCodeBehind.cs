using Google.Apis.Auth.OAuth2;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Threading;
using System.Windows.Forms;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;

namespace WordCatcher
{
    public partial class Form1 : IWordTabHost
    {
        static string ApplicationName = "Flashcards";        

        private DriveService _driveService;
        private SheetsService _sheetsService;
        private List<IWordFinder> _wordFinders = new List<IWordFinder>();

        private void InitService()
        {
            UserCredential credential;

            using (var stream =
                new FileStream(_config.ClientSecretFile, FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-flashcards.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile, DriveService.Scope.DriveMetadata },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                _driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }

            using (var stream =
                new FileStream(_config.ClientSecretFile, FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets-dotnet-flashcards.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new string[] { SheetsService.Scope.Spreadsheets, SheetsService.Scope.DriveFile, SheetsService.Scope.Drive },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                _sheetsService = new SheetsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
            }
        }

        private void InitFinders()
        {
            _wordFinders.Add(new DictionaryFinder(_config.Dictionary_SearchUrl, _config.Dictionary_TemplateFile));
            _wordFinders.Add(new GoogleFinder(_config.Google_SearchUrl, _config.Google_TemplateFile));
        }

        private void LoadChildren(string parentId, TreeNode parentNode)
        {
            string pageToken = null;

            do
            {
                var request = _driveService.Files.List();
                request.Q = $"(mimeType='application/vnd.google-apps.folder' or mimeType='application/vnd.google-apps.spreadsheet') and '{parentId}' in parents and trashed = false";
                request.Spaces = "drive";
                request.Fields = "nextPageToken, files(id, name, mimeType)";
                request.PageToken = pageToken;
                var result = request.Execute();
                var nodes = result.Files.Select(f =>
                {
                    var node = new TreeNode(f.Name);
                    node.Tag = f;

                    if (f.MimeType == "application/vnd.google-apps.folder")
                    {
                        var dummyNode = new TreeNode("#NOTLOADED#");
                        node.Nodes.Add(dummyNode);
                    }
                    else
                    {
                        node.NodeFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
                    }

                    return node;
                });

                (parentNode?.Nodes ?? driveTree.Nodes).AddRange(nodes.ToArray());
                pageToken = result.NextPageToken;
            }
            while (pageToken != null);
        }

        private void SaveRecord(string fileId, WordDefinition word)
        {
            var body = new ValueRange();
            body.Values = new List<IList<object>>()
            {
                new List<object>()
                {
                    word.Word, word.Texts[0], word.Texts[1], word.Texts[2], word.Texts[3], word.ExtraInfo
                }
            };

            var range = "Sheet1";
            var request = _sheetsService.Spreadsheets.Values.Append(body, fileId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var response = request.Execute();
        }


        private void CreateNewFile(TreeNode node, string name)
        {
            var folder = (Google.Apis.Drive.v3.Data.File)driveTree.SelectedNode.Tag;

            var sheet = new Spreadsheet();
            sheet.Properties = new SpreadsheetProperties()
            {
                Title = name
            };

            var request = _sheetsService.Spreadsheets.Create(sheet);
            sheet = request.Execute();

            var getRequest = _driveService.Files.Get(sheet.SpreadsheetId);
            getRequest.Fields = "parents, id, name, mimeType";
            var file = getRequest.Execute();
            var previousParents = String.Join(",", file.Parents);
            var updateRequest = _driveService.Files.Update(new Google.Apis.Drive.v3.Data.File(), sheet.SpreadsheetId);
            updateRequest.Fields = "id, parents";
            updateRequest.AddParents = folder.Id;
            updateRequest.RemoveParents = previousParents;
            file = updateRequest.Execute();

            var fileNode = new TreeNode(name);
            fileNode.Tag = file;
            fileNode.NodeFont = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            node.Nodes.Add(fileNode);
        }

        private void NewWordTab(string word = null)
        {
            var tab = new TabPage();
            var w = new WordControl(this);
            w.Init();
            tab.Controls.Add(w);
            tabControl1.TabPages.Add(tab);
            tabControl1.SelectTab(tab);
            
            if (word != null)
            {
                w.Search(word);
            }
        }

        #region IWordTabHost

        public IEnumerable<IWordFinder> Finders => _wordFinders;

        public void WordChanged(string word)
        {
            if (tabControl1.SelectedTab != null)
            {
                tabControl1.SelectedTab.Text = word;
            }
        }

        public void Save(WordDefinition word)
        {
            if (driveTree.SelectedNode == null)
            {
                MessageBox.Show("Select a file !");
            }
            else if ((driveTree.SelectedNode.Tag as Google.Apis.Drive.v3.Data.File).MimeType == "application/vnd.google-apps.folder")
            {
                MessageBox.Show("Select a file, not a folder !");
            }
            else
            {
                var file = (Google.Apis.Drive.v3.Data.File)driveTree.SelectedNode.Tag;
                SaveRecord(file.Id, word);
                MessageBox.Show("Saved ...");

                if (tabControl1.SelectedTab != null)
                {
                    tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                }
            }
        }

        #endregion
    }
}
