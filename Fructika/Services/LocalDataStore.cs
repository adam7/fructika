using Fructika.Helpers;
using Fructika.Models;
using LiteDB;
using Plugin.Multilingual;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Fructika.Services
{
    public class LocalDataStore : ILocalDataStore
    {
        private const string FoodsCollectionName = "foods";
        private const string FoodGroupsCollectionName = "foodGroups";
        static string FoodIndexName = "descriptionFullTextIndex";
        public static string DatabasePath => DependencyService.Get<IDataBaseAccess>().DatabasePath();

        public LocalDataStore()
        {
            var cultureInfo = CrossMultilingual.Current.CurrentCultureInfo;
            var indexName = $"food-{AppPreferences.SelectedLanguageCode}";
        }

        public void SaveFoodGroup(FoodGroup foodGroup)
        {
            // Get the local database (and create it if it doesn't exist)
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                var foodGroupCollection = database.GetCollection<FoodGroup>(FoodGroupsCollectionName);

                var query = Query.And(Query.EQ("ExternalId", foodGroup.ExternalId), Query.EQ("Language", "en"));

                var temp = foodGroupCollection.FindOne(query);

                if (temp != null)
                {
                    foodGroupCollection.Update(foodGroup);
                }
                else
                {
                    foodGroupCollection.Insert(foodGroup);
                }
            }
        }

        public void SaveFood(Food food)
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                var foodCollection = database.GetCollection<Food>(FoodsCollectionName);

                foodCollection.Upsert(food);
            }
        }

        public void SaveFoods(IEnumerable<Food> foods)
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                var foodCollection = database.GetCollection<Food>(FoodsCollectionName);

                foreach (var food in foods)
                {
                    foodCollection.Insert(food);
                }
                //foodCollection.InsertBulk(foods);
            }
        }

        public IEnumerable<FoodGroup> GetFoodGroups()
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                var foodGroupCollection = database.GetCollection<FoodGroup>(FoodGroupsCollectionName);

                return foodGroupCollection.FindAll();
            }
        }

        public FoodGroup GetFoodGroup(string id)
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                var foodGroupCollection = database.GetCollection<FoodGroup>(FoodGroupsCollectionName);

                return foodGroupCollection.FindById(id);
            }
        }

        public IEnumerable<Food> SearchFoods(string search, bool includeUnknownFructose)
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                var collection = database.GetCollection<Food>(FoodsCollectionName);
                
                return collection.Find(Query.Contains(nameof(Food.Description), search?.ToLower()));
            }
        }

        public void IndexFoods()
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                var collection = database.GetCollection<Food>(FoodsCollectionName);

                collection.EnsureIndex(food => food.Description.ToLowerInvariant());

                foreach(var food in collection.FindAll())
                {

                }
            }
        }

        public void DropFoods()
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                if (database.CollectionExists(FoodsCollectionName))
                {
                    database.DropCollection(FoodsCollectionName);
                }
            }
        }

        public void DropFoodGroups()
        {
            using (LiteDatabase database = new LiteDatabase(DatabasePath))
            {
                database.DropCollection(FoodsCollectionName);
            }
        }
    }
}
