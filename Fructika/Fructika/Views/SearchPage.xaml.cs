using Fructika.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fructika.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
        SearchViewModel viewModel;

        public SearchPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new SearchViewModel();
        }

        async void OnFoodSelected(object sender, SelectedItemChangedEventArgs args)
        {
            // Manually deselect item first to try and avoid the horrible highlighting in android
            ItemsListView.SelectedItem = null;

            var item = args.SelectedItem as FoodViewModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new FoodDetailPage(item));
        } 
    }
}