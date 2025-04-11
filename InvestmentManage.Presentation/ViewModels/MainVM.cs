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

namespace InvestmentManage.Presentation.ViewModels
{
    internal class MainVM : NotifyPropertyChanged
    {
        private readonly PaletteHelper _paletteHelper = new PaletteHelper();
        public MainVM()
        {
            ChipCFList = new RelayCommand(rightDrawerHost);
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
