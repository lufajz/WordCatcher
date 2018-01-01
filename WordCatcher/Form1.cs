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
            NewWordTab();
        }

        private void Instance_Shortcut(object sender, GlobalKeyShortcutEventArgs args)
        {
            if (args.Pressed)
            {
                Activate();
                // wordTxt.Text = Clipboard.GetText();
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

        private void newFileBtn_Click(object sender, EventArgs e)
        {
            if (driveTree.SelectedNode == null)
            {
                MessageBox.Show("Select a file !");
            }
            else
            {
                CreateNewFile(driveTree.SelectedNode, newFileTxt.Text);
                MessageBox.Show("Created ...");
            }
        }

        private void newTabBtn_Click(object sender, EventArgs e)
        {
            NewWordTab();
        }

        private void addToQueueBtn_Click(object sender, EventArgs e)
        {
            queueLbx.Items.Add(Clipboard.GetText());
        }

        private void takeFromQueueBtn_Click(object sender, EventArgs e)
        {
            if (queueLbx.SelectedItem != null)
            {
                NewWordTab((string)queueLbx.SelectedItem);
                queueLbx.Items.Remove(queueLbx.SelectedItem);
            }
        }

        private void addFileToFavoritesBtn_Click(object sender, EventArgs e)
        {
            if (!driveTree.SelectedNode.IsSpreadsheet())
            {
                MessageBox.Show("Select spreadsheet !");
            }
            else
            {
                var fileName = (driveTree.SelectedNode.Tag as File).Name;

                if (!favoritesLbx.Items.Contains(fileName))
                {
                    AddToFavorites(fileName);
                    favoritesLbx.Items.Add(fileName);
                }
            }
        }
    }
}
