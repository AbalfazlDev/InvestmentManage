using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Presentation.Helpers;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;
using static InvestmentManage.Presentation.ViewModels.MenuVM;

namespace InvestmentManage.Presentation.ViewModels
{
    internal class MarketVM:NotifyPropertyChanged
    {
        public ObservableCollection<MarketType> Markets { get; set; }

        private MarketType _selectedMarket;
        public MarketType SelectedMarket
        {
            get => _selectedMarket;
            set
            {
                _selectedMarket = value;
                OnPropertyChanged(nameof(SelectedMarket));
            }
        }

        // دیکشنری برای نگاشت Enum به مسیر آیکون
        public Dictionary<MarketType, string> MarketIcons { get; set; }

        public MarketVM()
        {
            Markets = new ObservableCollection<MarketType>(
                Enum.GetValues(typeof(MarketType)).Cast<MarketType>()
            );

            // تنظیم آیکون‌ها برای هر بازار
            MarketIcons = new Dictionary<MarketType, string>
        {
            { MarketType.StockExchange, $"pack://application:,,,/InvestmentManage.Presentation;component/Resources/Icons/OTCIcon.ico" },
            { MarketType.OTCMarket, "pack://application:,,,/InvestmentManage.Presentation;component/Resources/Icons/OTCIcon.ico" },
            { MarketType.CommoditiesExchange, "pack://application:,,,/InvestmentManage.Presentation;component/Resources/Icons/OTCIcon.ico" },
            { MarketType.EnergyExchange, $"pack://application:,,,/InvestmentManage.Presentation;component/Resources/Icons/OTCIcon.ico" }
        };
        }

    }
}
