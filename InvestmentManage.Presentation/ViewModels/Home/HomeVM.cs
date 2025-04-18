using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Domain.Model.Font;
using InvestmentManage.Presentation.Helpers.Language;
using InvestmentManage.Presentation.Views;

namespace InvestmentManage.Presentation.ViewModels.Home
{
    class HomeVM : FontSizeModel
    {

        #region Application Language

        public string LblWelcomeUser {  get; set; }
        public CapitalStatusVM CapitalStatusViewModel { get; set; }
        public CapitalStatusV CapitalStatusView { get; set; }

        #endregion



        public HomeVM()
        {
            CapitalStatusViewModel = new CapitalStatusVM();
            CapitalStatusView = new CapitalStatusV();
            CapitalStatusView.DataContext = CapitalStatusViewModel;

            ResetLanguage();
        }


        public void ResetTheme()
        {
            CapitalStatusViewModel.ResetColor();
        }

        public void ResetLanguage()
        {
            LblWelcomeUser = LocalizationLanguage.GetString("TxtWelcome");
        }

    }
}
