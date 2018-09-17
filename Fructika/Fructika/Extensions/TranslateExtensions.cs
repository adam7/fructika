using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using Microsoft.AppCenter.Analytics;
using Plugin.Multilingual;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


// This class is specifically for a Xamarin Forms application usage
// Added as part of the Multilingual Plugin https://github.com/CrossGeeks/MultilingualPlugin
namespace Fructika.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        const string ResourceId = "Fructika.Resources.AppResources";

        static readonly Lazy<ResourceManager> resourceManager = new Lazy<ResourceManager>(() =>
            new ResourceManager(ResourceId, typeof(TranslateExtension).GetTypeInfo().Assembly));

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Text))
                return "";

            var cultureInfo = CrossMultilingual.Current.CurrentCultureInfo;

            var translation = resourceManager.Value.GetString(Text, cultureInfo) ?? "";

            if (translation == "")
            {
                // Couldn't find the translation so log 
                Analytics.TrackEvent("Missing Translation", new Dictionary<string, string> {
                    { "Culture", cultureInfo.ToString()},
                    { "Text", Text }
                });
            }

            return translation;
        }
    }
}