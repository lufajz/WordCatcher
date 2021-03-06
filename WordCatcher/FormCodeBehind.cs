﻿using Google.Apis.Auth.OAuth2;
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
using Newtonsoft.Json;
using Google.Apis.Upload;

namespace WordCatcher
{
    public partial class Form1 : IWordTabHost
    {
        static string ApplicationName = "Flashcards";        

        private DriveService _driveService;
        private SheetsService _sheetsService;
        private Google.Apis.Drive.v3.Data.File _configFile;
        private SharedConfig _sharedConfig;
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
                    new string[] { DriveService.Scope.Drive, DriveService.Scope.DriveFile, DriveService.Scope.DriveMetadata, DriveService.Scope.DriveMetadata },
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;

                _driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                // search for config file
                var request = _driveService.Files.List();
                request.Q = $"name = 'flashcards_config.json' and trashed = false";
                request.Spaces = "drive";
                request.Fields = "files(id)";

                try
                {
                    var result = request.Execute();

                    if (result.Files.Count == 0)
                    {
                        // TODO: create config file
                        var configFile = new Google.Apis.Drive.v3.Data.File();
                        configFile.MimeType = MimeTypes.ConfigJson;
                        configFile.Name = "flashcards_config.json";
                        configFile.Parents = new List<string> { "root" }; // TODO

                        _sharedConfig = new SharedConfig();

                        using (var s = new MemoryStream())
                        {
                            var binary = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_sharedConfig));
                            s.Write(binary, 0, binary.Length);
                            s.Seek(0, SeekOrigin.Begin);
                            var u = _driveService.Files.Create(configFile, s, MimeTypes.ConfigJson);
                            u.Upload();
                            _configFile = u.ResponseBody;
                        }
                    }
                    else
                    {
                        using (var ms = new MemoryStream())
                        {
                            _configFile = result.Files.First();
                            _driveService.Files.Get(_configFile.Id).DownloadWithStatus(ms);
                            ms.Seek(0, SeekOrigin.Begin);
                            _sharedConfig = new JsonSerializer().Deserialize<SharedConfig>(new JsonTextReader(new StreamReader(ms, Encoding.UTF8)));
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private async Task SaveSharedConfigAsync()
        {
            using (var s = new MemoryStream())
            {
                var binary = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(_sharedConfig));
                s.Write(binary, 0, binary.Length);
                s.Seek(0, SeekOrigin.Begin);

                var request = _driveService.Files.Update(new Google.Apis.Drive.v3.Data.File(), _configFile.Id, s, MimeTypes.ConfigJson);
                request.ProgressChanged += (p) =>
                {
                    if (p.Status == UploadStatus.Failed)
                    {
                        throw p.Exception;
                    }
                };

                await request.UploadAsync();
            }
        }

        private void AppendToSheet(string fileId, string range, ValueRange body)
        {
            var request = _sheetsService.Spreadsheets.Values.Append(body, fileId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var response = request.Execute();
        }

        private Google.Apis.Drive.v3.Data.File SetParent(string fileId, string parentId)
        {
            var getRequest = _driveService.Files.Get(fileId);
            getRequest.Fields = "parents";
            var file = getRequest.Execute();
            var previousParents = String.Join(",", file.Parents);

            var updateRequest = _driveService.Files.Update(new Google.Apis.Drive.v3.Data.File(), fileId);
            updateRequest.Fields = "parents";
            updateRequest.AddParents = parentId;
            updateRequest.RemoveParents = previousParents;
            return updateRequest.Execute();
        }

        private void SaveRecord(string fileId, WordDefinition word)
        {
            var body = new ValueRange {
                Values = new List<IList<object>> {
                    new List<object>()
                    {
                        word.Word, word.Texts[0], word.Texts[1], word.Texts[2], word.Texts[3], word.ExtraInfo
                    }
                }
            };

            AppendToSheet(fileId, "Sheet1", body);
        }

        private void CreateNewFile(TreeNode node, string name)
        {
            var sheet = new Spreadsheet();
            sheet.Properties = new SpreadsheetProperties()
            {
                Title = name
            };

            var request = _sheetsService.Spreadsheets.Create(sheet);
            sheet = request.Execute();

            var body = new ValueRange
            {
                Values = new List<IList<object>> {
                    new List<object>() { "*", "name", name },
                    new List<object>() { "*", "card-theme", "Paper - Clear" },
                    new List<object>() { "Text 1", "Text 2", "Text 3", "Text 4", "Notes", "Extra Info" },
                }
            };

            AppendToSheet(sheet.SpreadsheetId, "Sheet1", body);

            var folder = (Google.Apis.Drive.v3.Data.File)driveTree.SelectedNode.Tag;
            var file = SetParent(sheet.SpreadsheetId, folder.Id);

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

        private void AddToFavorites(string fileName)
        {

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
