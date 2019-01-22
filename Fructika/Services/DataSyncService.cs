using System.Linq;
using Fructika.Models;
using System.Threading.Tasks;

namespace Fructika.Services
{
    public class DataSyncService
    {
        IRemoteDataStore RemoteDataStore { get; set; }
        ILocalDataStore LocalDataStore { get; set; }

        public DataSyncService(IRemoteDataStore remoteDataStore, ILocalDataStore localDataStore)
        {
            RemoteDataStore = remoteDataStore;
            LocalDataStore = localDataStore;
        }

        public DataSyncService() : this(new RemoteDataStore(), new LocalDataStore()) { }

        public async Task SyncAllAsync()
        {
            await SyncFoodGroupsAsync();
            await SyncFoodsAsync(); 
        }

        public async Task SyncFoodGroupsAsync()
        {
            LocalDataStore.DropFoodGroups();

            var remoteFoodGroups = await RemoteDataStore.GetFoodGroupsAsync();
            
            foreach(var remoteFoodGroup in remoteFoodGroups)
            {
                LocalDataStore.SaveFoodGroup(new FoodGroup(remoteFoodGroup));
            }
        }

        public async Task SyncFoodsAsync()
        {
            LocalDataStore.DropFoods();

            var foods = from remoteFood in await RemoteDataStore.GetFoodsAsync()
                        select new Food(remoteFood);

            LocalDataStore.SaveFoods(foods);

            LocalDataStore.IndexFoods();
        }
    }
}
