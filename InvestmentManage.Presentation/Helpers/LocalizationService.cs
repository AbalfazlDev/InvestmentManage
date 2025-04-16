using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Presentation.Helpers.Language;

namespace InvestmentManage.Presentation.Helpers
{
    public static class LocalizationService
    {
        public static LocalizationHelper Instance { get; private set; }

        static LocalizationService()
        {
            var rm = new ResourceManager("InvestmentManage.Presentation.Resources.Language.FaLan", typeof(LocalizationService).Assembly);
            Instance = new LocalizationHelper(rm);
        }

        public static void ChangeLanguage(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);

            var newRm = cultureCode == "fa"
                ? new ResourceManager("InvestmentManage.Presentation.Resources.Language.FaLan", typeof(LocalizationService).Assembly)
                : new ResourceManager("InvestmentManage.Presentation.Resources.Language.EnLan", typeof(LocalizationService).Assembly);
           
            Instance = new LocalizationHelper(newRm);
            Instance.Refresh();

            LanguageChanged?.Invoke(null, EventArgs.Empty);
        }

        public static event EventHandler LanguageChanged;
    }

}
