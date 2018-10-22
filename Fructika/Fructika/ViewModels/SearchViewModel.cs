using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Fructika.Helpers;
using System.Threading;
using Fructika.Extensions;

namespace Fructika.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        string searchText = string.Empty;
        bool showResults = false;
        bool showNoResults = false;
        CancellationTokenSource cancellationTokenSource;

        public Command SearchFoodsCommand { get; set; }
        public ObservableCollection<FoodViewModel> Foods { get; set; }

        public bool ShowResults
        {
            get { return showResults; }
            set { SetProperty(ref showResults, value); }
        }
        public bool ShowNoResults
        {
            get { return showNoResults; }
            set { SetProperty(ref showNoResults, value); }
        }
        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }

        protected async void OnSearchTextChanged()
        {
            try
            {
                if (string.IsNullOrEmpty(searchText))
                {
                    if(Foods != null)
                    {
                        Foods?.Clear();
                    }
                    SetResultVisibility(false, false);
                }
                if (searchText.Length > 3)
                {
                    await ExecuteSearchFoodsCommand();
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
            SearchFoodsCommand = new Command(async () => await ExecuteSearchFoodsCommand());
        }

        public async Task ExecuteSearchFoodsCommand()
        {
            if(cancellationTokenSource != null)
            {
                cancellationTokenSource.Cancel();
            }

            cancellationTokenSource = new CancellationTokenSource();
            SetResultVisibility(true, false);

            try
            {
                Foods.Clear();
                var includUnknownFructose = AppPreferences.UnknownFructose;
                foreach (var food in await FoodDataStore.SearchFoodsAsync(SearchText, includUnknownFructose, cancellationTokenSource.Token))
                {
                    Foods.Add(new FoodViewModel(food));
                }
				SetResultVisibility(false, true);

                Analytics.TrackEvent("Search Completed", new Dictionary<string, string> { { "Search Text", SearchText } });
            }
            catch(TaskCanceledException)
            {
                // Task was canceled so just handle the exception and move on
            }
            catch (Exception exception)
            {
                Analytics.TrackEvent("Error Searching Food", new Dictionary<string, string> { { "Exception Message", exception.Message } });
            }
        }

        void SetResultVisibility(bool showSearching, bool showResults)
        {
            IsSearching = showSearching;
            ShowResults = showResults && Foods?.Count > 0;
            ShowNoResults = showResults && !ShowResults;
        }
    }
}
