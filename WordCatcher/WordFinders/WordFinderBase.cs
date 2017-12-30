using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCatcher
{
    public abstract class WordFinderBase
    {
        protected string _url;
        protected string _templateFile;
        
        protected WordFinderBase(string url, string templateFile)
        {
            _url = url;
            _templateFile = templateFile;
        }
    }
}
