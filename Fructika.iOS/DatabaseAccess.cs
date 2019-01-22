using System;
using System.IO;

namespace Fructika.iOS
{
    public class DatabaseAccess
    {
        public string DatabasePath()
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, Constants.DatabaseName);
        }
    }
}