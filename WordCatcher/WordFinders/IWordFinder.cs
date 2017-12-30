using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCatcher
{
    public interface IWordFinder
    {
        string Name { get; }
        void FindDefinition(string word, WebBrowser browser);
    }
}
