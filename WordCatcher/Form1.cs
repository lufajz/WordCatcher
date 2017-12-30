using Google.Apis.Drive.v3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCatcher
{
    public partial class Form1 : Form
    {
        private IConfig _config;
        private List<IWordFinder> _wordFinders = new List<IWordFinder>();

        public Form1(IConfig config)
        {
            _config = config;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if !KEYHOOKS_DISABLED
            GlobalKeyShortcut.Instance.addShortcut(
                new Keys[] { Keys.LControlKey, Keys.W });
            GlobalKeyShortcut.Instance.Shortcut += Instance_Shortcut;
            GlobalKeyShortcut.Instance.init();
#endif
            InitService();
            LoadChildren("root", null);

            _wordFinders.Add(new DictionaryFinder(_config.Dictionary_SearchUrl, _config.Dictionary_TemplateFile));
            _wordFinders.Add(new GoogleFinder(_config.Google_SearchUrl, _config.Google_TemplateFile));

            tabControl1.TabPages.Clear();

            foreach (var finder in _wordFinders)
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

        private void Instance_Shortcut(object sender, GlobalKeyShortcutEventArgs args)
        {
            if (args.Pressed)
            {
                Activate();
                wordTxt.Text = Clipboard.GetText();
            }
        }

        private void goBtn_Click(object sender, EventArgs e)
        {
            Search(wordTxt.Text);
        }

        private void wordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                Search(wordTxt.Text);
            }
        }

        private void driveTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
        }

        private void driveTree_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Action == TreeViewAction.Expand)
            {
                var dummyNode = e.Node.Nodes.OfType<TreeNode>().FirstOrDefault(n => n.Text == "#NOTLOADED#");

                if (dummyNode != null)
                {
                    var file = (File)e.Node.Tag;
                    LoadChildren(file.Id, dummyNode.Parent);
                    dummyNode.Parent.Nodes.Remove(dummyNode);
                }
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (driveTree.SelectedNode == null)
            {
                MessageBox.Show("Select a file !");
            }
            else
            {
                var file = (File)driveTree.SelectedNode.Tag;
                SaveRecord(file.Id);
            }
        }
    }
}
