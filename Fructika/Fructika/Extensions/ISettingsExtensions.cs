using Fructika.Helpers;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fructika.Extensions
{
    public static class ISettingsExtensions
    {
        public static bool GetUnknownFructose(this ISettings settings)
        {
          return settings.GetValueOrDefault(Constants.UnknownFructoseKey, false);
        }

        public static decimal GetFructoseWarningLevel(this ISettings settings)
        {
            return settings.GetValueOrDefault(Constants.FructoseWarningLevelKey, 10m);
        }
    }
}
