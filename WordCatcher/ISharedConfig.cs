using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCatcher
{
    public interface ISharedConfig
    {
        IList<string> Favorites { get; set; }
    }
}
