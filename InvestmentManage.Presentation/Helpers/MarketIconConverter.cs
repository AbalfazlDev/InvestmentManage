using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using InvestmentManage.Presentation.ViewModels;
using static InvestmentManage.Presentation.ViewModels.MenuVM;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.Helpers
{
    internal class MarketIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is MarketType marketType)
            {
                var viewModel = new MarketVM();
                if (viewModel.MarketIcons.TryGetValue(marketType, out string iconPath))
                {
                    return iconPath; // مسیر آیکون را برمی‌گرداند
                }
            }
            return "Icons/default.png"; // اگر مقدار ناشناخته بود، آیکون پیش‌فرض
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
