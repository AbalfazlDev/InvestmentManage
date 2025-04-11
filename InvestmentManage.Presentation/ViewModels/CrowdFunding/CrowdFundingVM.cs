using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.Presentation.Helpers;

namespace InvestmentManage.Presentation.ViewModels.CrowdFunding
{
    internal class CrowdFundingVM : NotifyPropertyChanged
    {
        private ObservableCollection<string> _crowdFundingItems;
        public ObservableCollection<string> CrowdFundingItems
        {
            get { return _crowdFundingItems; }
            set
            {
                _crowdFundingItems = value;
                OnPropertyChanged(nameof(CrowdFundingItems));
            }
        }

        public CrowdFundingVM()
        {
            CrowdFundingItems = new ObservableCollection<string> { "آیتم ۱", "آیتم ۲", "آیتم ۳" };
        }

    }
}
