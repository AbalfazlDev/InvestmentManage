using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvestmentManage.Domain.Model.EnumM;

namespace InvestmentManage.Domain.Model
{
    public class MenuItemModel
    {
        public MenuType Type { get; set; }
        public string DisplayText { get; set; }
        public string Icon { get; set; }
    }
}
