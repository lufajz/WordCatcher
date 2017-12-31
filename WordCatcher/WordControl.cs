using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCatcher
{
    public partial class WordControl : UserControl
    {
        private IWordTabHost _provider;

        public WordControl(IWordTabHost provider)
        {
            InitializeComponent();

            _provider = provider;
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            _provider.Save(new WordDefinition
            {
                Word = wordTxt.Text,
                ExtraInfo = extraInfoTxt.Text,
                Texts = new string[]
                {
                    text1Txt.Text,
                    text2Txt.Text,
                    text3Txt.Text,
                    text4Txt.Text
                }
            });
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tabControl2.SelectedTab.Controls[0].Focus();
        }

        private void toText1Btn_Click(object sender, EventArgs e)
        {
            var controls = new TextBox[] { text1Txt, text2Txt, text3Txt, text4Txt };
            var index = Int32.Parse((sender as Control).Tag.ToString()) - 1;

            controls[index].Text = Clipboard.GetText();
            tabControl2.SelectTab(index);
        }
    }
}
