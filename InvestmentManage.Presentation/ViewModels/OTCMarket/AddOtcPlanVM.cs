using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Domain.Model.Font;
using InvestmentManage.Presentation.Helpers.Language;
using PropertyChanged;

namespace InvestmentManage.Presentation.ViewModels.OTCMarket
{
    [AddINotifyPropertyChangedInterface]
    public class AddOtcPlanVM:FontSizeModel
    {
        public string LblOtcName { get; set; }
        public AddOtcPlanVM()
        {
        }

        public void ResetLanguage()
        {
            LblOtcName = LocalizationLanguage.GetString("OTCName");
        }

    }
}
