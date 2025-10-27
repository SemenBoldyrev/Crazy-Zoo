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
            switch (language)
            {
                case Languages.English:
                    cultureInfo = new CultureInfo("en");
                    break;
                case Languages.Russian:
                    cultureInfo = new CultureInfo("ru");
                    break;
                default:
                    cultureInfo = new CultureInfo("en");
                    break;
            }

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
