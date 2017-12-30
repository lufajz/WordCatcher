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
    }
}
