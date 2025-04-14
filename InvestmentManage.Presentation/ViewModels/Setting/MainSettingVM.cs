using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.ViewModels.Setting
{
    public class MainSettingVM
    {
        public MainSettingVM()
        {
            LVSettingItems = new ObservableCollection<SettingItems>(Enum.GetValues(typeof(SettingItems)).Cast<SettingItems>());
        }
        public ObservableCollection<SettingItems> LVSettingItems { get; set; }

        public enum SettingItems
        {
            Font,
            Theme,
            Databases
        }
    }
}
