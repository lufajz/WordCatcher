using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WordCatcher
{
    public class Config : IConfig
    {
        public string Dictionary_SearchUrl => "http://www.dictionary.com/browse/{WORD}";
        public string Dictionary_TemplateFile => $"{ExePath}\\Template_Dictionary.html";

        public string Google_SearchUrl => "https://www.google.com/search?q={WORD}+definition";
        public string Google_TemplateFile => $"{ExePath}\\Template_Google.html";

        public string ClientSecretFile => $"{ExePath}\\client_id.json";

        private string ExePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
