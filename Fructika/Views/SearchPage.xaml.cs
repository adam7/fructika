using Fructika.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Fructika.Views
{


    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("SearchText", "query")]
    public partial class SearchPage : ContentPage
    {
        SearchViewModel viewModel = new SearchViewModel();

        // Unnecessary backing value but seems like the compiler throws out the SearchText 
        // property otherwise
        string searchText = null;
        public string SearchText
        {
            get { return viewModel.SearchText; }
            set
            {                
                // Set the unnecessary backing variable as well ... don't know why
                viewModel.SearchText = searchText = value;
            }
        }
        
        public SearchPage()
        {
            InitializeComponent();

            var foodSearchHandler = new FoodSearchHandler();

            Shell.SetSearchHandler(this, new FoodSearchHandler());

            // Set the unnecessary backing variable as well ... don't know why
            searchText = viewModel.SearchText;

            BindingContext = viewModel;
        }
    }
}