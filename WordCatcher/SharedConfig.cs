using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCatcher
{
    public class SharedConfig : ISharedConfig
    {
        public IList<string> Favorites { get; set; } = new List<string>();
        public IList<string> Queue { get; set; } = new List<string>();
    }
}
