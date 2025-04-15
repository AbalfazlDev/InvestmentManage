﻿using System;
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

        public event PropertyChangedEventHandler PropertyChanged;

        public string MenuItemList => LocalizationManager.GetString("MenuItemList");
        //public string DarkMode = LocalizationManager.GetString("DarkMode");

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

     


        // پراپرتی برای نمایش FlowDirection (برای راست به چپ یا چپ به راست)
        //public FlowDirection AppFlowDirection =>
        //    CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "fa"
        //    ? FlowDirection.RightToLeft
        //    : FlowDirection.LeftToRight;

        #endregion
        public Dictionary<MarketType, string> MarketIcons { get; set; }

        public MenuVM()
        {
            Markets = new ObservableCollection<MarketType>(Enum.GetValues(typeof(MarketType)).Cast<MarketType>());
            Markets = new ObservableCollection<MarketType>(
            Enum.GetValues(typeof(MarketType)).Cast<MarketType>());
            TxtColor = Brushes.Red;
        }

        public ObservableCollection<MarketType> Markets { get; set; }

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

        //public ObservableCollection<MarketType> Items { get; set; }
        public Action<MarketType> OnItemSelected { get; set; }
        //public Action<bool> IsSettingView {  get; set; }

        //private MarketType _selectedItem;
        //public MarketType SelectedItem
        //{
        //    get => _selectedItem;
        //    set
        //    {
        //        _selectedItem = value;
        //        OnItemSelected?.Invoke(_selectedItem); 
        //    }
        //}

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

        private void darkMod(bool isDark)
        {
            if (isDark)
            {
                ThemeSet.ChangeDarkMode(isDark);
                LocalizationManager.SetLanguageT("fa");
                DarkMode = LocalizationManager.GetString("DarkMode");
            }
            else
            {
                ThemeSet.ChangeDarkMode(isDark);
                LocalizationManager.SetLanguageT("en");
                DarkMode = LocalizationManager.GetString("DarkMode");
            }

        }
        private void resetLanguage()
        {

        }
    }
}
