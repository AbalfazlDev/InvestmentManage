using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using InvestmentManage.Presentation.Helpers.Language;

namespace InvestmentManage.Presentation.Helpers
{
    public class EnumToDescriptionConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return LocalizationLanguage.GetString($"{value}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}