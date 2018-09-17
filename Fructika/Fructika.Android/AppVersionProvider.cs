using Fructika.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppVersionProvider))]
namespace Fructika.Droid
{
    public class AppVersionProvider: IAppVersionProvider
    {
        public string Version
        {
            get
            {
                var context = Android.App.Application.Context;
                var info = context.PackageManager.GetPackageInfo(context.PackageName, 0);

                return $"{info.VersionName}.{info.VersionCode.ToString()}";
            }
        }
    }
}