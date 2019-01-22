using Plugin.Multilingual;
using System;
using System.Globalization;
using System.Linq;
using Xamarin.Essentials;

namespace Fructika.Helpers
{
    public static class AppPreferences
    {
        public static string[] SupportedLanguageCodes => new string[] { "en", "es", "fr", "de" };

        static CultureInfo cultureInfo = CrossMultilingual.Current.CurrentCultureInfo;

        public static bool UnknownFructose
        {
            get => Preferences.Get(Constants.UnknownFructoseKey, false);
            set => Preferences.Set(Constants.UnknownFructoseKey, value);
        }

        public static double FructoseWarningLevel
        {
            get => Convert.ToDouble(Preferences.Get(Constants.FructoseWarningLevelKey, 10d));
            set => Preferences.Set(Constants.FructoseWarningLevelKey, value);
        }

        public static string SelectedLanguageCode
        {
            get => Preferences.Get(Constants.SelectedLanguageCode, null) ?? GetIndexLanguageCode(cultureInfo);
            set => Preferences.Set(Constants.SelectedLanguageCode, value);
        }

        static string GetIndexLanguageCode(CultureInfo cultureInfo)
        {
            var languageCode = cultureInfo.TwoLetterISOLanguageName;

            return SupportedLanguageCodes.Contains(languageCode) ? languageCode : SupportedLanguageCodes.First();
        }
    }
}
