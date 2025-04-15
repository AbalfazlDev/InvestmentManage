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
    public static class LocalizationManager
    {
        // یک متغیر برای ResourceManager
        private static ResourceManager _resourceManager;

        static LocalizationManager()
        {
            // بارگذاری منابع برای زبان پیش‌فرض
            _resourceManager = new ResourceManager("InvestmentManage.Presentation.Resources.Language.EnLan", typeof(LocalizationManager).Assembly);
        }

        public static void SetLanguageT(string cultureCode)
        {
            if (cultureCode == "fa")
            {
                _resourceManager = new ResourceManager("InvestmentManage.Presentation.Resources.Language.FaLan", typeof(LocalizationManager).Assembly);
            }

            if (cultureCode == "en")
            {
                _resourceManager = new ResourceManager("InvestmentManage.Presentation.Resources.Language.EnLan", typeof(LocalizationManager).Assembly);
            }

            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign2.Defaults.xaml")
            });


            // تغییر زبان یا تم و بروز رسانی پنجره بدون ساخت پنجره جدید
            //Application.Current.MainWindow?.Close();
            //var newWindow = new MainV(); // پنجره جدید
            //newWindow.Show();


           // ری‌لود پنجره فعلی برای اعمال تغییرات
            //var currentWindow = Application.Current.MainWindow;

            //// ایجاد پنجره جدید (MainV.xaml)
            //var newWindow = (Window)Activator.CreateInstance(typeof(MainV));

            //// تنظیم پنجره جدید به عنوان پنجره اصلی
            //Application.Current.MainWindow = newWindow;

            //// نمایش پنجره جدید
            //newWindow.Show();

            //// بستن پنجره قبلی
            //currentWindow.Close();

        }

        public static void SetLanguage(string cultureCode)
        {
            var culture = new CultureInfo(cultureCode);

            // تغییر زبان سیستم
            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            // ری‌لود پنجره فعلی برای اعمال تغییرات
            var currentWindow = Application.Current.MainWindow;

            // ایجاد پنجره جدید (MainV.xaml)
            var newWindow = (Window)Activator.CreateInstance(typeof(MainV));

            // تنظیم پنجره جدید به عنوان پنجره اصلی
            Application.Current.MainWindow = newWindow;

            // نمایش پنجره جدید
            newWindow.Show();

            // بستن پنجره قبلی
            currentWindow.Close();
        }

        //public static string GetString(string key)
        //{
        //    return InvestmentManage.Presentation.Resources.Language.EnLan.ResourceManager
        //        .GetString(key, CultureInfo.CurrentUICulture) ?? $"[{key}]";
        //}

        public static string GetString(string key)
        {
            // دریافت مقدار از منابع با توجه به زبان و کلید
            return _resourceManager.GetString(key, Thread.CurrentThread.CurrentUICulture);
        }

    }
    //public static class LocalizationManager
    //{

    //    public static string GetString(string key)
    //    {
    //        return InvestmentManage.Presentation.Resources.Language.EnLan.ResourceManager
    //            .GetString(key, CultureInfo.CurrentUICulture) ?? $"[{key}]";
    //    }



    //}

}
