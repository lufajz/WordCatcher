using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Drive.v3.Data;

namespace WordCatcher
{
    public static class Extensions
    {
        public static bool IsSpreadsheet(this TreeNode node)
        {
            return MimeTypes.Spreadsheet.Equals((node?.Tag as File)?.MimeType);
        }

        public static bool IsFolder(this TreeNode node)
        {
            return MimeTypes.Folder.Equals((node?.Tag as File)?.MimeType);
        }
    }
}
