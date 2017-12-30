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
    public partial class Form1
    {
        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Flashcards";

        class FileItem
        {
            public string Id { get; set; }
            public List<FileItem> Children { get; } = new List<FileItem>();
        }

        private DriveService _driveService;
        private SheetsService _sheetsService;

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
                    new string[]{ DriveService.Scope.DriveReadonly },
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

        private void SaveRecord(string fileId)
        {
            var body = new ValueRange();
            body.Values = new List<IList<object>>()
            {
                new List<object>()
                {
                    "a", "b", "c"
                },

                new List<object>()
                {
                    "aa", "bb", "cc"
                }
            };

            var range = "Sheet1";
            var request = _sheetsService.Spreadsheets.Values.Append(body, fileId, range);
            request.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var response = request.Execute();
        }

        private void Search(string word)
        {
            foreach(var page in tabControl1.TabPages)
            {
                var tabPage = page as TabPage;
                var browser = tabPage.Controls.OfType<WebBrowser>().FirstOrDefault();

                if (browser != null)
                {
                    var finder = (IWordFinder)(tabPage.Tag);
                    finder.FindDefinition(word, browser);
                }                
            }            
        }
    }
}
