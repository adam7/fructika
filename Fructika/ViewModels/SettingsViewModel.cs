using Fructika.Helpers;
using Fructika.Extensions;
using Fructika.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Fructika.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        string selectedWarningLevelLabel;

        public Dictionary<string, double> WarningLevels
        {
            get
            {
                var values = new Dictionary<string, double>();

                for (double level = 0; level < 25; level += 1)
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
                AppPreferences.FructoseWarningLevel = warningLevel;
                selectedWarningLevelLabel = value;
            }
        }

        public bool EnableUnknownFructose
        {
            get => AppPreferences.UnknownFructose;
            set => AppPreferences.UnknownFructose = value;
        }

        public double FructoseWarningLevel
        {
            get => AppPreferences.FructoseWarningLevel;
            set
            {
                OnPropertyChanged(nameof(FructoseWarningLevel));
                AppPreferences.FructoseWarningLevel = value;
            }
        }

        public SettingsViewModel()
        {
            var fructoseWarningLevel = AppPreferences.FructoseWarningLevel;
            SelectedWarningLevelLabel = WarningLevels
                .FirstOrDefault(level => level.Value == AppPreferences.FructoseWarningLevel)
                .Key;
        }
    }
}
