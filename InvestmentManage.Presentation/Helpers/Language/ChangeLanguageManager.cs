using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using InvestmentManage.Presentation.Views;

namespace InvestmentManage.Presentation.Helpers.Language
{
    public static class ChangeLanguageManager
    {
        private static ResourceManager _resourceManager;

        static ChangeLanguageManager() => _resourceManager = new ResourceManager("InvestmentManage.Presentation.Resources.Language.EnLan", typeof(ChangeLanguageManager).Assembly);

        public static void SetLanguage(string cultureCode)
        {
            if (cultureCode == "fa")
                _resourceManager = new ResourceManager("InvestmentManage.Presentation.Resources.Language.FaLan", typeof(ChangeLanguageManager).Assembly);

            if (cultureCode == "en")
                _resourceManager = new ResourceManager("InvestmentManage.Presentation.Resources.Language.EnLan", typeof(ChangeLanguageManager).Assembly);

            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign2.Defaults.xaml")
            });
        }

        //public static void SetLanguage(string cultureCode)
        //{
        //    var culture = new CultureInfo(cultureCode);

        //    Thread.CurrentThread.CurrentUICulture = culture;
        //    Thread.CurrentThread.CurrentCulture = culture;

        //    var currentWindow = Application.Current.MainWindow;

        //    var newWindow = (Window)Activator.CreateInstance(typeof(MainV));

        //    Application.Current.MainWindow = newWindow;

        //    newWindow.Show();

        //    currentWindow.Close();
        //}

        public static string GetString(string key) => _resourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture);
    }

}
