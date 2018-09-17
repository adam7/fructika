using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Fructika.Models
{
    public class FoodGroup
    {
        static ISettings AppSettings => CrossSettings.Current;

        string SettingName { get => Regex.Replace(Name, @"[^A-Za-z0-9]+", ""); }

        public bool Enabled
        {
            get => AppSettings.GetValueOrDefault(SettingName, true);
            set => AppSettings.AddOrUpdateValue(SettingName, value);
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
