using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Fructika
{
    public class FoodSearchHandler : SearchHandler
    {
        public FoodSearchHandler()
        {
            SearchBoxVisibility = SearchBoxVisiblity.Expanded;
            IsSearchEnabled = true;
            ShowsResults = true;
            Placeholder = "Find a food...";
        }

        protected override void OnQueryConfirmed()
        {
            base.OnQueryConfirmed();
            var shell = Application.Current.MainPage as Shell;

            shell.GoToAsync($"app:///fructika/search?query={Query}", true);
        }

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            // Populate the suggestions 
            // ItemsSource = new List<string> { "one", "two" };
        }
    }
}
