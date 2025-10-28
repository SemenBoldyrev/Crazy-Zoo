using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crazy_Zoo.Usables.Script
{
    public static class LanguageManager
    {
        public enum Languages
        {
            English,
            Russian,
        }

        public static void SetLanguage(Languages language)
        {
            CultureInfo cultureInfo;
            string lang;
            switch (language)
            {
                case Languages.English:
                    cultureInfo = new CultureInfo("en");
                    lang = "en";
                    break;
                case Languages.Russian:
                    cultureInfo = new CultureInfo("ru");
                    lang = "ru";
                    break;
                default:
                    cultureInfo = new CultureInfo("en");
                    lang = "en";
                    break;
            }

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Application.Current.Resources.MergedDictionaries.Clear();
            ResourceDictionary resdict = new ResourceDictionary()
            {
                Source = new Uri($"Usables/Localization/ApplicationLocalization/MainMenuXamlLoc/MainXamlLoc.{lang}.xaml", UriKind.Relative)
            };
            Application.Current.Resources.MergedDictionaries.Add(resdict);
        }
    }
}
