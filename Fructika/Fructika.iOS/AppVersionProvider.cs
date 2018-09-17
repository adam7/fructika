using Foundation;
using Fructika.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppVersionProvider))]
namespace Fructika.iOS
{
    public class AppVersionProvider : IAppVersionProvider
    {
        public string Version => NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString();
    }
}