using Fructika.Helpers;
using Fructika.Extensions;
using Fructika.Models;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fructika.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        static ISettings AppSettings => CrossSettings.Current;

        string selectedWarningLevelLabel;

        public Dictionary<string, decimal> WarningLevels
        {
            get
            {
                var values = new Dictionary<string, decimal>();

                for (decimal level = 0m; level < 25; level += 1)
                {
                    values.Add($"{level:0.0}g", level);
                }
                return values;
            }
        }

        public IList<string> WarningLevelLabels => WarningLevels.Select(level => level.Key).ToList();

        public string SelectedWarningLevelLabel
        {
            get => selectedWarningLevelLabel;
            set
            {
                var warningLevel = WarningLevels.FirstOrDefault(level => level.Key == value).Value;
                AppSettings.AddOrUpdateValue(Constants.FructoseWarningLevelKey, warningLevel);
                selectedWarningLevelLabel = value;
            }
        }

        public bool EnableUnknownFructose
        {
            get => AppSettings.GetUnknownFructose();
            set => AppSettings.AddOrUpdateValue(Constants.UnknownFructoseKey, value);
        }

        public decimal FructoseWarningLevel
        {
            get => AppSettings.GetFructoseWarningLevel();
            set
            {
                OnPropertyChanged(nameof(FructoseWarningLevel));
                AppSettings.AddOrUpdateValue(Constants.FructoseWarningLevelKey, value);
            }
        }

        public SettingsViewModel()
        {
            var fructoseWarningLevel = AppSettings.GetFructoseWarningLevel();
            SelectedWarningLevelLabel = WarningLevels
                .FirstOrDefault(level => level.Value == fructoseWarningLevel).Key;
        }
    }
}
