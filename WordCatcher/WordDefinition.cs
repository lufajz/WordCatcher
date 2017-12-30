using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCatcher
{
    public class WordDefinition
    {
        public string Word { get; set; }
        public string[] Texts { get; set; } = new string[4];
        public string ExtraInfo { get; set; }
    }
}
