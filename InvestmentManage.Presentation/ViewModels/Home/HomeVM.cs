using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManage.Presentation.ViewModels.Home
{
    class HomeVM
    {
        #region 
        string userName = "Abalfazl";
        #endregion
        public string WellcomeUser { get; set; }

        public HomeVM()
        {
            WellcomeUser = "Good Evening " +  userName;
        }

    }
}
