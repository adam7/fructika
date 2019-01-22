using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Fructika.Helpers;

namespace Fructika.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        string searchText = string.Empty;

        public ObservableCollection<FoodViewModel> Foods { get; set; }

        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        protected void OnSearchTextChanged()
        {
            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    Foods?.Clear();
                }
                else
                {
                    SearchFoods();
                }
            }
            catch (Exception exception)
            {
                Analytics.TrackEvent("OnSearchTextChanged Error", new Dictionary<string, string> { { "Exception Message", exception.Message } });
            }
        }

        override protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            switch (propertyName)
            {
                case nameof(SearchText):
                    OnSearchTextChanged();
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }

        public SearchViewModel()
        {
            Foods = new ObservableCollection<FoodViewModel>();
            Title = "Search";
        }

        public void SearchFoods()
        {
            try
            {
                if (Foods?.Count > 0)
                {
                    Foods?.Clear();
                }
                foreach (var food in FoodDataStore.SearchFoods(SearchText, AppPreferences.UnknownFructose))
                {
                    Foods.Add(new FoodViewModel(food));
                }

                Analytics.TrackEvent("Search Completed", new Dictionary<string, string> { { "Search Text", SearchText } });
            }
            catch (Exception exception)
            {
                Analytics.TrackEvent("Error Searching Food", new Dictionary<string, string> { { "Exception Message", exception.Message } });
            }
        }
    }
}
