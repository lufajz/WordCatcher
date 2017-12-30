using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCatcher
{
    public partial class WordControl
    {
        private void Init()
        {
            tabControl1.TabPages.Clear();

            foreach (var finder in _provider.Finders)
            {
                var page = new TabPage(finder.Name);
                page.Tag = finder;

                var browser = new WebBrowser();
                browser.Dock = DockStyle.Fill;
                browser.ScriptErrorsSuppressed = true;
                page.Controls.Add(browser);

                tabControl1.TabPages.Add(page);
            }
        }

        private void Clear()
        {
            wordTxt.Text = "";
            extraInfoTxt.Text = "";
            text1Txt.Text = "";
            text2Txt.Text = "";
            text3Txt.Text = "";
            text4Txt.Text = "";
        }

        private void Search(string word)
        {
            foreach (var page in tabControl1.TabPages)
            {
                var tabPage = page as TabPage;
                var browser = tabPage.Controls.OfType<WebBrowser>().FirstOrDefault();

                if (browser != null)
                {
                    var finder = (IWordFinder)(tabPage.Tag);

                    try
                    {
                        finder.FindDefinition(word, browser);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, $"Finder {finder.Name} error");
                    }
                }
            }
        }

    }
}
