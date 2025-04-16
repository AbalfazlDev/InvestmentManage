using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;
using System.Windows.Data;

namespace InvestmentManage.Presentation.Helpers.Converter
{
    public class MarketTypeToResxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MarketType type)
            {
                string key = $"MarketType_{type}";
                return LocalizationService.Instance[key];
            }

            return value?.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }

}
