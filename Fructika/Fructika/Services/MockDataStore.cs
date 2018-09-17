using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Fructika.Models;

[assembly: Xamarin.Forms.Dependency(typeof(Fructika.Services.MockDataStore))]
namespace Fructika.Services
{
    public class MockDataStore : IDataStore<Food>
    {
        List<Food> items;

        public MockDataStore()
        {
            items = new List<Food>();
            var mockItems = new List<Food>
            {
                new Food { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
                new Food { Id = Guid.NewGuid().ToString(), Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }
                
        public Task<IEnumerable<string>> SearchSuggestions(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Food>> SearchFoodsAsync(string search)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Food>> GetFoodsAsync()
        {
            throw new NotImplementedException();
        }
    }
}