using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignColors;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.ObjectModel;
using InvestmentManage.Presentation.Helpers;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.ViewModels
{
    internal class MenuVM : NotifyPropertyChanged
    {
        public Dictionary<MarketType, string> MarketIcons { get; set; }

        public MenuVM()
        {
            Markets = new ObservableCollection<MarketType>(Enum.GetValues(typeof(MarketType)).Cast<MarketType>());
            Markets = new ObservableCollection<MarketType>(
            Enum.GetValues(typeof(MarketType)).Cast<MarketType>());
            TxtColor = Brushes.Red;
        }

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

        private Brush _txtColor;

        public Brush TxtColor
        {
            get { return _txtColor; }
            set
            {
                _txtColor = value;
                OnPropertyChanged();
            }
        }


        public void LBMarketTypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        public void LBMarketTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        public bool IsDarkMod
        {
            set
            {
                darkMod(value);
            }
        }

        private void darkMod(bool isDark)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();
            if (isDark)
            {
                theme.SetBaseTheme(BaseTheme.Dark);
                theme.PrimaryMid = new ColorPair(Colors.Purple, Colors.White);
                TxtColor = Brushes.BurlyWood;
            }
            else
            {
                theme.SetBaseTheme(BaseTheme.Light);
                TxtColor = Brushes.Yellow;

            }

            paletteHelper.SetTheme(theme);
        }



    }
}
