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
using static InvestmentManage.Domain.Model.EnumM;
using InvestmentManage.Presentation.Resources.Symbol;
using PropertyChanged;
using InvestmentManage.Domain.Model.Menu;
using InvestmentManage.Domain.Model.Font;


namespace InvestmentManage.Presentation.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class MenuVM : FontSizeModel
    {
        public FontFamily AppFontFamily { get; set; }
        public int AppFontSize { get; set; }
        public RelayCommand BtnSettings { get; set; }
        public string MenuItemList { get; set; }
        public string LblSettings { get; set; }
        public string LblSettingsIcon => SegoeIcons.Settings;
        public ObservableCollection<MenuItemModel> MenuItemst { get; set; }


        public string DarkMode { get; set; }


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

        private void darkMod(bool isDark)
        {
            ThemeSet.ChangeDarkMode(isDark ? ThemeModType.Dark : ThemeModType.Light);
        }

        public void ResetLanguage()
        {
            DarkMode = LocalizationLanguage.GetString("DarkMode");
            LblSettings = LocalizationLanguage.GetString("Setting");
            MenuItemList = LocalizationLanguage.GetString("MenuItemList");
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

        //private MenuType _selectedMenuType;
        //public MenuType SelectedMenuType
        //{
        //    get => _selectedMenuType;
        //    set
        //    {
        //        if (_selectedMenuType != value)
        //        {
        //            _selectedMenuType = value;

        //        }
        //    }
        //}

        public MenuType SelectedMenuType { get; set; }

        private string GetLocalizedText(MenuType type)
        {
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
