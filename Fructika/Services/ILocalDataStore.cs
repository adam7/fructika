using System.Collections.Generic;
using Fructika.Models;

namespace Fructika.Services
{
    public interface ILocalDataStore
    {
        FoodGroup GetFoodGroup(string id);
        IEnumerable<FoodGroup> GetFoodGroups();
        void SaveFoodGroup(FoodGroup foodGroup);
        void SaveFood(Food food);
        void SaveFoods(IEnumerable<Food> foods);
        IEnumerable<Food> SearchFoods(string search, bool includeUnknownFructose);
        void IndexFoods();
        void DropFoods();
        void DropFoodGroups();
    }
}