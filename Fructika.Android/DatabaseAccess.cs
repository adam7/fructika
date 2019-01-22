using Fructika.Droid;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseAccess))]
namespace Fructika.Droid
{
    public class DatabaseAccess : IDataBaseAccess
    {
        public string DatabasePath()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Constants.DatabaseName);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            return path;
        }
    }
}