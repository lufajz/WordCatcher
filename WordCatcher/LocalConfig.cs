using System.IO;
using System.Reflection;

namespace WordCatcher
{
    public class LocalConfig : ILocalConfig
    {
        public string Dictionary_SearchUrl => "http://www.dictionary.com/browse/{WORD}";
        public string Dictionary_TemplateFile => $"{ExePath}\\Template_Dictionary.html";

        public string Google_SearchUrl => "https://www.google.com/search?q={WORD}+definition";
        public string Google_TemplateFile => $"{ExePath}\\Template_Google.html";

        public string ClientSecretFile => $"{ExePath}\\client_id.json";

        private string ExePath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}
