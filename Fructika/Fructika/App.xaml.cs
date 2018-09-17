using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Fructika.Views;
using Xamarin.Forms;

namespace Fructika
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            
            MainPage = new MainPage();
            AppCenter.Start(Helpers.Constants.AppCenterAppSecret, typeof(Analytics), typeof(Crashes));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Analytics.TrackEvent("Start");
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
