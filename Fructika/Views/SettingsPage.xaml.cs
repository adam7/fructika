using Fructika.Services;
using Fructika.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fructika.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        SettingsViewModel viewModel = new SettingsViewModel();

        public SettingsPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected async void Refresh_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;

            button.IsVisible = false;

            var dataSyncService = new DataSyncService();
            await dataSyncService.SyncAllAsync();

            button.IsVisible = true;
        }
    }
}