using Fructika.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fructika.ViewModels
{
    public class GroupViewModel : BaseViewModel
    {
        FoodGroup group;
        bool enabled;

        public bool Enabled
        {
            get => group.Enabled;
            set
            {
                SetProperty(ref enabled, value);
                group.Enabled = value;
            }
        }

        public string Name => group.Name;
        public string FriendlyName => group.FriendlyName;
        public string Image => group.Image;
        public string Icon => group.Icon;

        public GroupViewModel(FoodGroup foodGroup)
        {
            group = foodGroup;
            enabled = foodGroup.Enabled;
        }
    }
}
