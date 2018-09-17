using Fructika.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fructika.Services
{
    public interface IDataStore<T>
    {
        Task<IEnumerable<string>> SearchSuggestions(string search);
        Task<IEnumerable<Food>> SearchFoodsAsync(string search);
        Task<IEnumerable<Food>> GetFoodsAsync();
    }
}
