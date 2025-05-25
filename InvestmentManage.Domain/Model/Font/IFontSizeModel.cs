using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManage.Domain.Model.Font
{
    public interface IFontSizeModel
    {
        public int SmallFontApp { get; set; }
        public int MediumFontApp { get; set; }
        public int LargeFontApp { get; set; }
    }
}
