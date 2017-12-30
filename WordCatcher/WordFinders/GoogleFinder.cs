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
    public class GoogleFinder : WordFinderBase, IWordFinder
    {
        public string Name => "Google";

        public GoogleFinder(string url, string templateFile) : base(url, templateFile)
        {
        }

        public void FindDefinition(string word, WebBrowser browser)
        {
            var url = _url.Replace("{WORD}", word);
            browser.Navigate(url);
        }
    }
}
