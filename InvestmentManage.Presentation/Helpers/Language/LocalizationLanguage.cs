using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManage.Presentation.Helpers.Language
{
    internal static class LocalizationLanguage
    {
        private static ResourceManager _resourceManager = new ResourceManager("InvestmentManage.Presentation.Resources.Language.Strings", typeof(LocalizationService).Assembly);
        private static CultureInfo _currentCulture = CultureInfo.CurrentCulture;


        public static string GetString(string key)
        {
            return _resourceManager.GetString(key, _currentCulture);
        }

        public static void SetLanguage(string cultureCode)
        {
            _currentCulture = new CultureInfo(cultureCode);
        }
    }
}
