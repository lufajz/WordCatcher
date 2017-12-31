using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCatcher
{
    public interface IWordTabHost
    {
        void WordChanged(string word);
        void Save(WordDefinition word);
        IEnumerable<IWordFinder> Finders { get; }
    }
}
