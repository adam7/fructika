using System.Collections.Generic;
using System.Threading.Tasks;
using Fructika.Models;

namespace Fructika.Services
{
    public interface IRemoteDataStore
    {
        Task<IEnumerable<RemoteFoodGroup>> GetFoodGroupsAsync();
        Task<IEnumerable<RemoteFood>> GetFoodsAsync();
    }
}