using Fructika.ViewModels;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace Fructika.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FoodDetailPage : ContentPage
    {
        FoodViewModel viewModel { get; set; }

        public FoodDetailPage(FoodViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }
    }
}