using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Fructika.Helpers
{
    public static class AppPreferences
    {
        public static bool UnknownFructose
        {
            get => Preferences.Get(Constants.UnknownFructoseKey, false);
            set => Preferences.Set(Constants.UnknownFructoseKey, value);
        }

        public static decimal FructoseWarningLevel
        {
            get => (decimal)Preferences.Get(Constants.FructoseWarningLevelKey, 10f);
            set => Preferences.Set(Constants.FructoseWarningLevelKey, (float)value);
        }
    }
}
