using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Classes
{
    public static class RelativePath
    {
        public static string GetFullPath(string path) {
            string sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sParentDirectory = Directory.GetParent(sCurrentDirectory).FullName;
            string sFilePath = Path.Combine(sParentDirectory, path);
            return sFilePath;
        }
    }
}
