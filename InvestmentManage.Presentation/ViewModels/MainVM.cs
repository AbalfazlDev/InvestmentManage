using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using InvestmentManage.Presentation.Helpers;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;
using InvestmentManage.Presentation.Helpers.Language;
using System.Windows.Controls;
using InvestmentManage.Presentation.Views.Setting;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;
using InvestmentManage.Presentation.Views;
using InvestmentManage.Presentation.Views.Home;
using System.Collections.ObjectModel;
using InvestmentManage.Presentation.ViewModels.Setting;
using InvestmentManage.Domain.Model;
using static InvestmentManage.Domain.Model.EnumM;
using PropertyChanged;

namespace InvestmentManage.Presentation.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class MainVM 
    {
        #region Application Language


        #endregion
        public static MenuVM MenuviewModel { get; set; }
        public static MenuV Menuview { get; set; }
        public static MainSettingVM MainSettingviewModel { get; set; }
        private static MainSettingV _mainSettingView { get; set; }

        public bool IsSettingView { get; set; }

        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        public MainVM()
        {
            MenuviewModel = new MenuVM();
            Menuview = new MenuV();
            MainSettingviewModel = new MainSettingVM();
            _mainSettingView = new MainSettingV();
            _mainSettingView.DataContext = MainSettingviewModel;
            MenuviewModel.OnItemSelected = LoadView;
            MainSettingviewModel.OnFontSizeSelected = changeLbFontSize;
            MainSettingviewModel.OnLanguageSelected = ChangeLanguage;
            MainSettingviewModel.ResetLanguage();


        }

        public FlowDirection AppFlowDirection { get; set; } = FlowDirection.LeftToRight;

        public UserControl SelectedView { get; set; }

        private void changeLbFontSize(FontSizeType fontSize)
        {
            switch (fontSize)
            {
                case FontSizeType.Small:
                    ChangeFontSize(10);
                    break;
                case FontSizeType.Medium:
                    ChangeFontSize(15);
                    break;
                case FontSizeType.Large:
                    ChangeFontSize(20);
                    break;
                case FontSizeType.ExtraLarge:
                    ChangeFontSize(27);
                    break;

            }
        }
        private void ChangeFontSize(int normalFontSize)
        {
            //SmalFontApp = (normalFontSize * 7) / 10;
            //MediumFontApp = normalFontSize;
            //LargeFontApp = (normalFontSize * 12) / 10;
            //MenuviewModel.
        }

        private void ChangeLanguage(EnumM.LanguageList language)
        {
            switch (language)
            {
                case EnumM.LanguageList.English:
                    LocalizationLanguage.SetLanguage("en");
                    AppFlowDirection = FlowDirection.LeftToRight;
                    break;

                case EnumM.LanguageList.Farsi:
                    LocalizationLanguage.SetLanguage("fa");
                    AppFlowDirection = FlowDirection.RightToLeft;
                    break;

            }
            MainSettingviewModel.ResetLanguage();
            MenuviewModel.ResetLanguage();
        }

        public void LoadView(MenuType item)
        {
            MainSettingviewModel.ResetLanguage();
            switch (item)
            {
                case MenuType.Home:
                    SelectedView = new HomeV();
                    break;
                case MenuType.Settings:
                    //SelectedView = _mainSettingView;
                    //SelectedView.DataContext = MainSettingviewModel;
                    IsSettingView = true;
                    SelectedView = new HomeV();
                    break;
                default:
                    SelectedView = null;
                    break;
            }
        }


        public void ListBox_Selected(object sender, RoutedEventArgs e)
        {

        }



        private RelayCommand _chipCFList;

        public RelayCommand ChipCFList
        {
            get { return _chipCFList; }
            set { _chipCFList = value; }
        }


    }
}
