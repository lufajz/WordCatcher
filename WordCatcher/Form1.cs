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
            InitFinders();
            LoadChildren("root", null);
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
            NewWord(wordTxt.Text);
        }

        private void wordTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                NewWord(wordTxt.Text);
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
                SaveRecord(file.Id, wordTxt.Text, text1Txt.Text, text2Txt.Text, text3Txt.Text, text4Txt.Text, extraInfoTxt.Text);
                HistoryBack();
                MessageBox.Show("Saved ...");
            }
        }

        private void newFileBtn_Click(object sender, EventArgs e)
        {
            if (driveTree.SelectedNode == null)
            {
                MessageBox.Show("Select a file !");
            }
            else
            {
                CreateNewFile(driveTree.SelectedNode, newFileTxt.Text);
            }
        }

        private void toText1Btn_Click(object sender, EventArgs e)
        {
            var controls = new TextBox[] { text1Txt, text2Txt, text3Txt, text4Txt };
            var index = Int32.Parse((sender as Control).Tag.ToString()) - 1;

            controls[index].Text = Clipboard.GetText();
            tabControl2.SelectTab(index);
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            HistoryBack();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedTab.Controls[0].Focus();
        }
    }
}
