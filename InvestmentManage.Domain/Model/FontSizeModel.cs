using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;


namespace InvestmentManage.Domain.Model
{
    [AddINotifyPropertyChangedInterface]
    public class FontSizeModel
    {
        public int SmalFontApp { get; set; }
        public int MediumFontApp { get; set; }
        public int LargeFontApp { get; set; }
    }
}
