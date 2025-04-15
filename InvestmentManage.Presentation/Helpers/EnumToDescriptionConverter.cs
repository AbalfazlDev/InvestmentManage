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
        //public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    if (value is Enum enumValue)
        //    {
        //        var description = enumValue.GetType()
        //            .GetField(enumValue.ToString())
        //            .GetCustomAttributes(typeof(DescriptionAttribute), false)
        //            .FirstOrDefault() as DescriptionAttribute;

        //        return description?.Description ?? enumValue.ToString();
        //    }
        //    return value;
        //}
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return ChangeLanguageManager.GetString($"{value}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}