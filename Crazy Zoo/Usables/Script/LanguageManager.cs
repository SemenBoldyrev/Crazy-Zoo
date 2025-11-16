using Crazy_Zoo.Interfaces;
using Crazy_Zoo.Usables.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Crazy_Zoo.Usables.Script
{
    public class LanguageManager: ILanguageManager
    {

        public readonly List<string> SupportedLanguages = new List<string> { "English"};

        public void SetLanguage(LanguageSet language)
        {
            CultureInfo cultureInfo;
            switch (language)
            {
                case LanguageSet.English:
                    cultureInfo = new CultureInfo("en");
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
