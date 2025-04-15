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

namespace InvestmentManage.Presentation.ViewModels
{
    internal class MainVM : NotifyPropertyChanged
    {
        #region Application Language


        #endregion
        public MenuVM MenuviewModel { get; set; }
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        public MainVM()
        {
            ChipCFList = new RelayCommand(rightDrawerHost);
            MenuviewModel = new MenuVM();
            MenuviewModel.OnItemSelected = LoadView;
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

        


        public void LoadView(MarketType item)
        {
            switch (item)
            {
                case MarketType.Home:
                    SelectedView = new HomeV();
                    break;
                case MarketType.Setting:
                    SelectedView = new MainSettingV();
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
