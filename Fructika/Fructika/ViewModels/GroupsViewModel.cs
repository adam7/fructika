using Fructika.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fructika.ViewModels
{
    public class GroupsViewModel : BaseViewModel
    {
        public ObservableCollection<GroupViewModel> Groups { get; set; }

        public GroupsViewModel()
        {
            var groupViewModels = from foodGroup in FoodDataStore.GetFoodGroups().OrderBy(g => g.Name)
                                  select new GroupViewModel(foodGroup);
            Groups = new ObservableCollection<GroupViewModel>(groupViewModels);
        }
    }
}
