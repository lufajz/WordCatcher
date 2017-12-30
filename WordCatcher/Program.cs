using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCatcher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // test();
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TODO: DI
            var form = new Form1(new Config());
            Application.Run(form);
        }

        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/drive-dotnet-quickstart.json
        static string[] Scopes = { DriveService.Scope.DriveReadonly };
        static string ApplicationName = "Flashcards";

        public static void test()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_id.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/drive-dotnet-flashcards.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
                Console.WriteLine("Credential file saved to: " + credPath);
            }

            // Create Drive API service.
            var service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            // Define parameters of request.
            FilesResource.ListRequest listRequest = service.Files.List();
            listRequest.PageSize = 10;
            // listRequest.Fields = "nextPageToken, files(id, name, )";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            Console.WriteLine("Files:");
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    Console.WriteLine("{0} ({1})", file.Name, file.Id);
                    Console.WriteLine($"{file.Kind}, {file.MimeType}");

                    if (file.Properties != null)
                    {
                        Console.WriteLine("PROPS:");
                        var props = file.Properties.Select(p => $"{p.Key} = {p.Value}");
                        Console.WriteLine(String.Join("\r\n", props));
                    }

                    
                }
            }
            else
            {
                Console.WriteLine("No files found.");
            }
            Console.Read();
        }
    }
}