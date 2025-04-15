using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Presentation.Helpers.Language;

namespace InvestmentManage.Presentation.ViewModels.Home
{
    class HomeVM
    {

        #region Application Language

        public string LblWelcomeUser => LocalizationManager.GetString("TxtWelcome");

        #endregion



        public HomeVM()
        {
        }

    }
}
