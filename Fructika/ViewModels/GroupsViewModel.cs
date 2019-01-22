using Fructika.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Fructika.ViewModels
{
    public class GroupsViewModel : BaseViewModel
    {
        public ObservableCollection<GroupViewModel> Groups { get; set; }

        public GroupsViewModel()
        {
            var foodGroups = FoodDataStore.GetFoodGroups();
            var groupViewModels = from foodGroup in foodGroups.OrderBy(g => g.Name)
                                  select new GroupViewModel(foodGroup);
            Groups = new ObservableCollection<GroupViewModel>(groupViewModels);
        }
    }
}
