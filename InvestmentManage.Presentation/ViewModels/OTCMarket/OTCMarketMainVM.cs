using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Domain.Model.Font;
using InvestmentManage.Presentation.Helpers.Language;
using InvestmentManage.Presentation.Views.OTCMarket;
using PropertyChanged;

namespace InvestmentManage.Presentation.ViewModels.OTCMarket
{
    [AddINotifyPropertyChangedInterface]
    public class OTCMarketMainVM:FontSizeModel
    {
        public AddOtcPlanV UcAddOtcPlan { get; set; }
        public AddOtcPlanVM AddOtcPlanViewModel {  get; set; }
        public string LblBtnCloseDialog { get; set; }
        public OTCMarketMainVM()
        {
            UcAddOtcPlan = new AddOtcPlanV();
            AddOtcPlanViewModel = new AddOtcPlanVM();
            UcAddOtcPlan.DataContext = AddOtcPlanViewModel;
            ResetLanguage();
        }

        public void ResetLanguage()
        {
            LblBtnCloseDialog = LocalizationLanguage.GetString("Close");
            AddOtcPlanViewModel.ResetLanguage();
        }

    }
}
