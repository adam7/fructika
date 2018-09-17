using Fructika.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fructika.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupsPage : ContentPage
    {
        GroupsViewModel viewModel;

        public GroupsPage()
        {
            InitializeComponent();
        }

        void Handle_GroupTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            
            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            BindingContext = viewModel = new GroupsViewModel();
            base.OnAppearing();
        }
    }
}
