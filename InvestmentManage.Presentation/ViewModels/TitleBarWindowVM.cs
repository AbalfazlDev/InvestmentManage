using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Presentation.Helpers;
using System.Windows.Input;
using System.Windows;
using System.Reflection.Metadata;

namespace InvestmentManage.Presentation.ViewModels
{
    public class TitleBarWindowVM
    {
        public ICommand MoveWindowCommand { get; }
        public ICommand CloseWindowCommand { get; }
        public ICommand MaximizeWindowCommand { get; }
        public ICommand MinimizeWindowCommand { get; }

        public TitleBarWindowVM()
        {
            MoveWindowCommand = new RelayCommand(ExecuteMoveWindow);
            CloseWindowCommand = new RelayCommand(ExecuteCloseWindow);
            MaximizeWindowCommand = new RelayCommand(ExecuteMaximizeWindow);
            MinimizeWindowCommand = new RelayCommand(ExecuteMinimizeWindow);
        }

        private void ExecuteMinimizeWindow(object obj)
        {
            if (obj is Window window)
            {
                window.WindowState = WindowState.Minimized;
            }
        }

        private void ExecuteMaximizeWindow(object obj)
        {
            if (obj is Window window)
            {
                if (window.WindowState == WindowState.Normal)
                    window.WindowState = WindowState.Maximized;
                else
                    window.WindowState = WindowState.Normal;

            }
        }

        private void ExecuteCloseWindow(object obj)
        {
            if (obj is Window window)
                window.Close();
        }

        private void ExecuteMoveWindow(object parameter)
        {
            if (parameter is Window window)
            {
                window.DragMove();
            }
        }


    }
}
