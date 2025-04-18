﻿using System;
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
using InvestmentManage.Presentation.ViewModels.Home;
using InvestmentManage.Presentation.Views.OTCMarket;
using InvestmentManage.Presentation.ViewModels.OTCMarket;
using InvestmentManage.Domain.Model.Font;

namespace InvestmentManage.Presentation.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    internal class MainVM : FontSizeModel
    {
        public static MenuVM MenuviewModel { get; set; }
        public static MenuV Menuview { get; set; }
        public static MainSettingVM MainSettingviewModel { get; set; }
        private static MainSettingV _mainSettingView { get; set; }
        public static OTCMarketMainV OTCMarketMainView { get; set; }
        private static OTCMarketMainVM OTCMarketMainViewModel { get; set; }
        public FlowDirection AppFlowDirection { get; set; } = FlowDirection.LeftToRight;
        public UserControl SelectedView { get; set; }
        private HomeV HomeView { get; set; }
        public HomeVM HomeViewModel { get; set; }
        public bool IsSettingView { get; set; }

        public MainVM()
        {
            MenuviewModel = new MenuVM();
            HomeViewModel = new HomeVM();
            Menuview = new MenuV();
            HomeView = new HomeV();
            OTCMarketMainViewModel = new OTCMarketMainVM();
            OTCMarketMainView = new OTCMarketMainV();
            OTCMarketMainView.DataContext = OTCMarketMainViewModel;
            MainSettingviewModel = new MainSettingVM();
            _mainSettingView = new MainSettingV();
            HomeView.DataContext = HomeViewModel;
            _mainSettingView.DataContext = MainSettingviewModel;
            MenuviewModel.OnItemSelected = LoadView;
            MainSettingviewModel.OnFontSizeSelected = changeLbFontSize;
            MainSettingviewModel.OnFontSizeChanged = ChangeFontSize;
            MainSettingviewModel.OnLanguageSelected = ChangeLanguage;
            MainSettingviewModel.ResetLanguage();
            changeLbFontSize(FontSizeType.Medium);
            LoadView(MenuType.Home);
        }


        private void changeLbFontSize(FontSizeType fontSize)
        {
            switch (fontSize)
            {
                case FontSizeType.Small:
                    MainSettingviewModel.FontSizeSlider = 10;
                    ChangeFontSize(10);
                    break;
                case FontSizeType.Medium:
                    MainSettingviewModel.FontSizeSlider = 15;
                    ChangeFontSize(15);
                    break;
                case FontSizeType.Large:
                    MainSettingviewModel.FontSizeSlider = 20;
                    ChangeFontSize(20);
                    break;
                case FontSizeType.ExtraLarge:
                    MainSettingviewModel.FontSizeSlider = 27;
                    ChangeFontSize(27);
                    break;
            }
        }
        private void ChangeFontSize(int normalFontSize)
        {
            applyFontSize(MenuviewModel, normalFontSize);
            applyFontSize(MainSettingviewModel, normalFontSize);
            applyFontSize(HomeViewModel, normalFontSize);
            applyFontSize(OTCMarketMainViewModel, normalFontSize);
            applyFontSize(OTCMarketMainViewModel.AddOtcPlanViewModel, normalFontSize);
        }

        private void applyFontSize(IFontSizeModel vm, int normalFontSize)
        {
            SmallFontApp = (normalFontSize * 6) / 10;
            MediumFontApp = normalFontSize;
            LargeFontApp = (normalFontSize * 13) / 10;

            vm.SmallFontApp = SmallFontApp;
            vm.MediumFontApp = MediumFontApp;
            vm.LargeFontApp = LargeFontApp;
        }

        private void ChangeLanguage(LanguageList language)
        {
            HomeViewModel.ResetTheme();
            switch (language)
            {
                case LanguageList.English:
                    LocalizationLanguage.SetLanguage("en");
                    AppFlowDirection = FlowDirection.LeftToRight;
                    break;
                case LanguageList.Turkish:
                    LocalizationLanguage.SetLanguage("tr");
                    AppFlowDirection = FlowDirection.LeftToRight;
                    break;

                case LanguageList.Farsi:
                    LocalizationLanguage.SetLanguage("fa");
                    AppFlowDirection = FlowDirection.RightToLeft;
                    break;
                case LanguageList.Arabi:
                    LocalizationLanguage.SetLanguage("ar");
                    AppFlowDirection = FlowDirection.RightToLeft;
                    break;

            }
            MainSettingviewModel.ResetLanguage();
            MenuviewModel.ResetLanguage();
            HomeViewModel.ResetLanguage();
            OTCMarketMainViewModel.ResetLanguage();
        }

        public void LoadView(MenuType item)
        {
            MainSettingviewModel.ResetLanguage();
            switch (item)
            {
                case MenuType.Home:
                    SelectedView = HomeView;
                    break;
                case MenuType.Settings:
                    //SelectedView = _mainSettingView;
                    //SelectedView.DataContext = MainSettingviewModel;
                    IsSettingView = true;
                    break;
                case MenuType.OTCMarket:
                    SelectedView = OTCMarketMainView;
                    break;
                default:
                    SelectedView = null;
                    break;
            }
        }

    }
}
