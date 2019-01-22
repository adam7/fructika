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
    public partial class GroupsPage : ContentPage
    {
        GroupsViewModel viewModel = new GroupsViewModel();

        public GroupsPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}