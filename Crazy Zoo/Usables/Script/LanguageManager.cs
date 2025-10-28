using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crazy_Zoo.Usables.Script
{
    public static class LanguageManager
    {

        public static readonly List<string> SupportedLanguages = new List<string> { "English", "Русский" };
        public enum Languages
        {
            English,
            Русский,
        }

        public static void SetLanguageByStr(string language)
        {
            switch (language)
            {
                case "English":
                    SetLanguage(Languages.English);
                    break;
                case "Русский":
                    SetLanguage(Languages.Русский);
                    break;
                default:
                    SetLanguage(Languages.English);
                    break;
            }
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
                case Languages.Русский:
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

            //for dynamic XAML localization
            Application.Current.Resources.MergedDictionaries.Clear();

            //Basically changes the resource with localized one using force
            foreach (string pth in new List<string> {
                "Usables/Localization/ApplicationLocalization/MainMenuXamlLoc/MainXamlLoc.{0}.xaml",
                "Usables/Localization/ApplicationLocalization/WizardMenuXamlLoc/WizardXamlLoc.{0}.xaml",
                "Usables/Localization/ApplicationLocalization/BacteriaXamlLoc/BacteriaXamlLoc.{0}.xaml"
            })
            {
                var resdict = new ResourceDictionary { Source = new Uri(string.Format(pth, lang), UriKind.Relative) };
                Application.Current.Resources.MergedDictionaries.Add(resdict);
            }
        }
    }
}
