using Xamarin.Forms;
using Xamarin.Essentials;

namespace Fructika
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            VersionTracking.Track();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            if (VersionTracking.IsFirstLaunchEver || VersionTracking.IsFirstLaunchForCurrentBuild)
            {
                // Do first time run stuff here, e.g. load food & group data
                //var syncService = new DataSyncService(new RemoteDataStore(), new LocalDataStore());
                //syncService.SyncAll();
            }
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
