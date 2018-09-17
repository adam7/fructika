using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fructika.Models;
using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System.Threading;
using Plugin.Multilingual;
using System.Globalization;

namespace Fructika.Services
{
    public class FoodsDataStore
    {
        SearchCredentials searchCredentials = new SearchCredentials(Helpers.Constants.SearchApiKey);
        SearchIndexClient searchIndexClient;
        string searchWildcard = "*";
        SearchParameters DefaultSearchParameters => new SearchParameters
        {
            SearchMode = SearchMode.Any,
            QueryType = QueryType.Full
        };

        public FoodsDataStore()
        {
            var cultureInfo = CrossMultilingual.Current.CurrentCultureInfo;
            var indexName = $"food-{GetIndexLanguageCode(cultureInfo)}";

            searchIndexClient = new SearchIndexClient("fructose", indexName, searchCredentials);
        }

        string GetIndexLanguageCode(CultureInfo cultureInfo)
        {
            var supportedLanguageCodes = new string[] { "es", "fr", "de" };
            var languageCode = cultureInfo.TwoLetterISOLanguageName;

            return supportedLanguageCodes.Contains(languageCode) ? languageCode : "en";
        }

        public async Task<IEnumerable<Food>> GetFoodsAsync(bool includeUnknownFructose, CancellationToken cancellationToken)
        {
            return await SearchFoodsAsync(string.Empty, includeUnknownFructose, cancellationToken);
        }

        public IEnumerable<FoodGroup> GetFoodGroups()
        {
            var searchParameters = new SearchParameters
            {
                SearchMode = SearchMode.Any,
                QueryType = QueryType.Full,
                Facets = new string[] { "foodGroup" },
                Top = 0
            }; 
            var includeUnknownFructose = true;

            if (!includeUnknownFructose)
            {
                searchParameters.Filter += "fructose ne null ";
            }

            var documentSearchResult = searchIndexClient.Documents
                .SearchAsync<Food>(searchWildcard, searchParameters);
       
            return new FoodGroup[]
            {
                new FoodGroup("Beef Products", "", "group_109599"),
                new FoodGroup("Baked Products", "", "group_156096"),
                new FoodGroup("Vegetables and Vegetable Products", "", "group_298710"),
                new FoodGroup("Soups, Sauces, and Gravies", "", "group_422025"),
                new FoodGroup("Lamb, Veal, and Game Products", "", "group_365019"),
                new FoodGroup("Poultry Products", "", "group_271121"),
                new FoodGroup("Legumes and Legume Products", "", "group_128426"),
                new FoodGroup("Beverages", "", "group_335257"),
                new FoodGroup("Baby Foods", "", "group_267381"),
                new FoodGroup("Fast Foods", "", "group_105699"),
                new FoodGroup("Fruits and Fruit Juices", "", "group_296131"),
                new FoodGroup("Sweets", "", "group_302505"),
                new FoodGroup("Breakfast Cereals", "", "group_228657"),
                new FoodGroup("Pork Products", "", "group_291658"),
                new FoodGroup("Dairy and Egg Products", "", "group_394688"),
                new FoodGroup("Finfish and Shellfish Products", "", "group_146792"),
                new FoodGroup("Fats and Oils", "", "group_262616"),
                new FoodGroup("Cereal Grains and Pasta", "", "group_44723"),
                new FoodGroup("Snacks", "", "group_381292"),
                new FoodGroup("Sausages and Luncheon Meats", "", "group_326864"),
                new FoodGroup("American Indian/Alaska Native Foods", "", "group_329043"),
                new FoodGroup("Nut and Seed Products", "", "group_195632"),
                new FoodGroup("Meals, Entrees, and Side Dishes", "", "group_388602"),
                new FoodGroup("Restaurant Foods", "", "group_254650"),
                new FoodGroup("Spices and Herbs", "", "group_264152")
            };
        }

        public FoodGroup GetFoodGroup(string groupName)
        {
            return GetFoodGroups().FirstOrDefault(group => group.Name == groupName);
        }
        
        public async Task<IEnumerable<Food>> SearchFoodsAsync(string search, bool includeUnknownFructose, CancellationToken cancellationToken)
        {
            search = string.IsNullOrWhiteSpace(search) ? searchWildcard : AppendTildasToSearchWords(search);

            var searchParameters = DefaultSearchParameters;

            if (!includeUnknownFructose)
            {
                searchParameters.Filter += "fructose ne null ";
            }

            var documentSearchResult = await searchIndexClient.Documents                
                .SearchAsync<Food>(search, searchParameters, null, cancellationToken);

            var enabledFoodGroupNames = GetFoodGroups()
                .Where(group => group.Enabled)
                .Select(group => group.Name);

            var searchResults = documentSearchResult.Results.Select(result => result.Document)
                .Where(result => enabledFoodGroupNames.Contains(result.FoodGroup));

            if(search == "*"){
               searchResults = searchResults.OrderBy(result => result.Description);
            }

             return searchResults.AsEnumerable();
        }


        string AppendTildasToSearchWords(string search)
        {
            var words = search.Trim().Split(" ".ToCharArray());

            return $"{string.Join("~1 ", words)}~1";
        }
    }
}
