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
using InvestmentManage.Domain.Model;
using static InvestmentManage.Domain.Model.EnumM;
using InvestmentManage.Presentation.Resources.Symbol;

namespace InvestmentManage.Presentation.ViewModels
{
    internal class MenuVM : FontSizeModel
    {

        #region Application Language
        public FontFamily AppFontFamily { get; set; }
        public int AppFontSize { get; set; }
        public RelayCommand BtnSettings { get; set; }
        public string MenuItemList => LocalizationLanguage.GetString("MenuItemList");
        public string LblSettings { get; set; }
        public string LblSettingsIcon => SegoeIcons.Settings;

        private string _darkMode;

        public string DarkMode
        {
            get { return _darkMode; }
            set
            {
                _darkMode = value;
            }
        }

        #endregion
        public Dictionary<MarketType, string> MarketIcons { get; set; }

        public MenuVM()
        {
            //Markets = new ObservableCollection<MarketType>(Enum.GetValues(typeof(MarketType)).Cast<MarketType>());

            //MarketsLang = new ObservableCollection<string>() { "Hello" };
            //MarketsLang.Add("Hello") ;
            AppFontSize = 10;
            BtnSettings = new RelayCommand(FuncBtnSettings);
            MenuItemst = new ObservableCollection<MenuItemModel>();
            ResetLanguage();
        }
        private void FuncBtnSettings(object sender)
        {
            OnItemSelected.Invoke(MenuType.Settings);
        }
        //public ObservableCollection<MarketType> Markets { get; set; }
        ////public ObservableCollection<string> MarketsLang { get; set; } = new ObservableCollection<string>();
        //private ObservableCollection<string> myVar;

        //public ObservableCollection<string> MarketsLang
        //{
        //    get { return myVar; }
        //    set { myVar = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public List<string> MenuItems { get; set; }



        //private MenuType _selectedMarket;
        //public MenuType SelectedMarket
        //{
        //    get => _selectedMarket;
        //    set
        //    {
        //        _selectedMarket = value;
        //        OnPropertyChanged(nameof(SelectedMarket));
        //    }
        //}

        public Action<MenuType> OnItemSelected { get; set; }

        public void LBMarketTypes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        public void LBMarketTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnItemSelected.Invoke(SelectedMenuType);

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
            DarkMode = LocalizationLanguage.GetString("DarkMode");
            LblSettings = LocalizationLanguage.GetString("Setting");
            MenuItemst.Clear();
            foreach (MenuType type in Enum.GetValues(typeof(MenuType)))
            {
                if (type == MenuType.Settings) break;
                MenuItemst.Add(new MenuItemModel
                {
                    Type = type,
                    DisplayText = GetLocalizedText(type),
                    Icon = GetMenuIcon(type)
                });
            }
        }

        private string GetMenuIcon(MenuType type)
        {
            switch (type)
            {
                case MenuType.Home:
                    return SegoeIcons.Home;
                case MenuType.StockExchange:
                    return SegoeIcons.StockExchange;
                case MenuType.OTCMarket:
                    return SegoeIcons.OTCMarket;
                case MenuType.CommoditiesExchange:
                    return SegoeIcons.CommoditiesExchange;
                case MenuType.EnergyExchange:
                    return SegoeIcons.EnergyExchange;
                case MenuType.Settings:
                    return SegoeIcons.Settings;

            }
            return SegoeIcons.LoadIssue;
        }

        private MenuType _selectedMenuType;
        public MenuType SelectedMenuType
        {
            get => _selectedMenuType;
            set
            {
                if (_selectedMenuType != value)
                {
                    _selectedMenuType = value;

                }
            }
        }




        public ObservableCollection<MenuItemModel> MenuItemst { get; set; }


        private string GetLocalizedText(MenuType type)
        {
            // مثلا بر اساس زبان فعلی یا منطق دلخواه
            return type switch
            {
                MenuType.Home => LocalizationLanguage.GetString("Home"),
                MenuType.StockExchange => LocalizationLanguage.GetString("StockExchange"),
                MenuType.OTCMarket => LocalizationLanguage.GetString("OTCMarket"),
                MenuType.CommoditiesExchange => LocalizationLanguage.GetString("CommoditiesExchange"),
                MenuType.EnergyExchange => LocalizationLanguage.GetString("EnergyExchange"),
                MenuType.Settings => LocalizationLanguage.GetString("Setting"),
                _ => type.ToString()
            };
        }

    }
}
