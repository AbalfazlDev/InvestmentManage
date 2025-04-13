using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using InvestmentManage.Presentation.Helpers.Language;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.Helpers.Converter
{
    class MarketTypeToStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MarketType type)
            {
                string key = $"MarketType_{type}";
                return  new ResourceManager("InvestmentManage.Presentation.Resources.Language.EnLan", typeof(LocalizationManager).Assembly).GetString(key, CultureInfo.CurrentUICulture) ?? type.ToString();
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
