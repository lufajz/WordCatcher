using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCatcher
{
    public class DictionaryFinder : WordFinderBase, IWordFinder
    {
        public string Name => "Dictionary";

        public DictionaryFinder(string url, string templateFile) : base(url, templateFile)
        {
        }

        public void  FindDefinition(string word, WebBrowser browser)
        {
            var url = _url.Replace("{WORD}", word);
            var template = System.IO.File.ReadAllText(_templateFile);

            using (var wc = new WebClient())
            {
                var originalContent = wc.DownloadString(url);
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(originalContent);

                var nodes = doc.DocumentNode.SelectNodes("//div[@class='source-data']");
                var content = new StringBuilder();
                foreach (HtmlNode node in nodes)
                {
                    content.Append(node.OuterHtml);
                }

                template = template.Replace("{{CONTENT}}", content.ToString());
            }

            browser.DocumentText = template;
        }
    }
}
