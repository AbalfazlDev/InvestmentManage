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
using InvestmentManage.Presentation.Helpers.ThemeH;
using InvestmentManage.Presentation.ViewModels;
using System.Windows;
using System.Globalization;
using InvestmentManage.Presentation.Views;
using InvestmentManage.Presentation.Helpers.Language;

namespace InvestmentManage.Presentation.ViewModels
{
    internal class MenuVM : NotifyPropertyChanged
    {

        #region Application Language

        public string MenuItemList => ChangeLanguageManager.GetString("MenuItemList");

        private string _darkMode;

        public string DarkMode
        {
            get { return _darkMode; }
            set
            {
                _darkMode = value;
                OnPropertyChanged(nameof(DarkMode));
            }
        }

        #endregion
        public Dictionary<MarketType, string> MarketIcons { get; set; }

        public MenuVM()
        {
            Markets = new ObservableCollection<MarketType>(Enum.GetValues(typeof(MarketType)).Cast<MarketType>());
            ResetLanguage();
            MarketsLang = new ObservableCollection<string>() { "Hello" };
            MarketsLang.Add("Hello") ;
        }

        public ObservableCollection<MarketType> Markets { get; set; }
        //public ObservableCollection<string> MarketsLang { get; set; } = new ObservableCollection<string>();
        private ObservableCollection<string> myVar;

        public ObservableCollection<string> MarketsLang
        {
            get { return myVar; }
            set { myVar = value;
                OnPropertyChanged();
            }
        }

        public List<string> MenuItems { get; set; }



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

        public Action<MarketType> OnItemSelected { get; set; }

        public void LBMarketTypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        public void LBMarketTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnItemSelected.Invoke(SelectedMarket);

        }

        public bool IsDarkMod
        {
            set
            {
                darkMod(value);
            }
        }

        private void darkMod(bool isDark) => ThemeSet.ChangeDarkMode(isDark);

        public void ResetLanguage()
        {
            DarkMode = ChangeLanguageManager.GetString("DarkMode");
        }
    }
}
