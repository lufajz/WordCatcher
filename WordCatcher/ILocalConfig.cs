using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCatcher
{
    public interface ILocalConfig
    {
        string Dictionary_SearchUrl { get; }
        string Dictionary_TemplateFile { get; }
        string Google_SearchUrl { get; }
        string Google_TemplateFile { get; }
        string ClientSecretFile { get; }
    }
}
