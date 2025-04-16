using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Domain.Model;
using InvestmentManage.Presentation.Helpers.Language;

namespace InvestmentManage.Presentation.ViewModels.Home
{
    class HomeVM : FontSizeModel
    {

        #region Application Language

        public string LblWelcomeUser => LocalizationLanguage.GetString("TxtWelcome");

        #endregion



        public HomeVM()
        {
        }

    }
}
