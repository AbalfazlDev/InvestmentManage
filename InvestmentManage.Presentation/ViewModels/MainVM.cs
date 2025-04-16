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

namespace InvestmentManage.Presentation.ViewModels
{
    internal class MainVM : NotifyPropertyChanged
    {
        #region Application Language


        #endregion
        public static MenuVM MenuviewModel { get; set; }
        public static MenuV Menuview { get; set; }
        public static MainSettingVM MainSettingviewModel { get; set; }
        private static MainSettingV _mainSettingView { get; set; }

        private bool _isSettingView;

        public bool IsSettingView
        {
            get { return _isSettingView; }
            set
            {
                _isSettingView = value;
                OnPropertyChanged();
            }
        }

        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        public MainVM()
        {
            ChipCFList = new RelayCommand(rightDrawerHost);
            MenuviewModel = new MenuVM();
            Menuview = new MenuV();
            MainSettingviewModel = new MainSettingVM();
            _mainSettingView = new MainSettingV();
            _mainSettingView.DataContext = MainSettingviewModel;
            MenuviewModel.OnItemSelected = LoadView;
            MainSettingviewModel.OnLanguageSelected = ChangeLanguage;
            MainSettingviewModel.ResetLanguage();


        }

        private UserControl _selectedView;
        public UserControl SelectedView
        {
            get => _selectedView;
            set
            {
                _selectedView = value;
                OnPropertyChanged(nameof(SelectedView));
            }
        }

        private void ChangeLanguage(EnumM.LanguageList language)
        {
            switch (language)
            {
                case EnumM.LanguageList.English:
                    ChangeLanguageManager.SetLanguage("en");
                    break;

                case EnumM.LanguageList.Farsi:
                    ChangeLanguageManager.SetLanguage("fa");
                    break;

            }
            MainSettingviewModel.ResetLanguage();
            MenuviewModel.ResetLanguage();
        }

        public void LoadView(MarketType item)
        {
            MainSettingviewModel.ResetLanguage();
            switch (item)
            {
                case MarketType.Home:
                    SelectedView = new HomeV();
                    break;
                case MarketType.Setting:
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

        public void rightDrawerHost(object obj)
        {
            IsRightDrawerHost = !IsRightDrawerHost;
        }

        public void ListBox_Selected(object sender, RoutedEventArgs e)
        {

        }

        private bool _isRightDrawerHost = false;

        public bool IsRightDrawerHost
        {
            get { return _isRightDrawerHost; }
            set
            {
                _isRightDrawerHost = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _chipCFList;

        public RelayCommand ChipCFList
        {
            get { return _chipCFList; }
            set { _chipCFList = value; }
        }


    }
}
