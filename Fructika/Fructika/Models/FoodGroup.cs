using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Essentials;

namespace Fructika.Models
{
    public class FoodGroup
    {
        string SettingName { get => Regex.Replace(Name, @"[^A-Za-z0-9]+", ""); }

        public bool Enabled
        {
            get => Preferences.Get(SettingName, true);
            set => Preferences.Set(SettingName, value);
        }

        public string Name { get; private set; }
        public string FriendlyName { get; private set; }
        public string Image { get; private set; }
        public string Icon { get; private set; }

        public FoodGroup(string name, string friendlyName, string imageId)
        {
            Name = name;
            FriendlyName = friendlyName;
            Image = $"{imageId}";
            Icon = $"icon_{imageId}";
        }
    }
}
