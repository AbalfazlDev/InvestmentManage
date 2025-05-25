using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using InvestmentManage.BusinessLogic.Services.FacadPattern;
using InvestmentManage.Domain.Model.Font;
using InvestmentManage.Domain.Model.Menu;
using InvestmentManage.Domain.Model.User;
using InvestmentManage.Presentation.Helpers;
using InvestmentManage.Presentation.Helpers.Converter;
using InvestmentManage.Presentation.Helpers.Language;
using InvestmentManage.Presentation.Helpers.ThemeH;
using InvestmentManage.Presentation.Resources.Symbol;
using PropertyChanged;
using static InvestmentManage.Domain.Model.EnumM;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;


namespace InvestmentManage.Presentation.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class MenuVM : FontSizeModel
    {
        private UserFacad _userFacad;
        public FontFamily AppFontFamily { get; set; }
        public int AppFontSize { get; set; }
        public RelayCommand BtnSettings { get; set; }
        public string MenuItemList { get; set; }
        public string LblSettings { get; set; }
        public string LblUser { get; set; }
        public string LblAccount { get; set; }
        public string LblSettingsIcon => SegoeIcons.Settings;
        public ObservableCollection<MenuItemModel> MenuItemst { get; set; }
        public ObservableCollection<UserM> UserList { get; set; }
        public string DarkMode { get; set; }
        public MenuType SelectedMenuType { get; set; }
        public UserM SelectedUser { get; set; }
        public Dictionary<MarketType, string> MarketIcons { get; set; }

        public MenuVM()
        {
            _userFacad = new UserFacad();
            UserList = _userFacad.GetUser.Execute().ToObservableCollection();
            AppFontSize = 10;
            BtnSettings = new RelayCommand(FuncBtnSettings);
            MenuItemst = new ObservableCollection<MenuItemModel>();
            SelectedUser = UserList.Last(); //for test
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
            LblUser = LocalizationLanguage.GetString("User");
            LblAccount = LocalizationLanguage.GetString("Account");
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
