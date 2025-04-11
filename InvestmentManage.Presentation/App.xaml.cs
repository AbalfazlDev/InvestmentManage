using System.Configuration;
using System.Data;
using System.Windows;
using InvestmentManage.Presentation.ViewModels;
using InvestmentManage.Presentation.Views;

namespace InvestmentManage.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainV win = new MainV();
            win.DataContext  = new MainVM();
            win.ShowDialog();
        }
    }

}
