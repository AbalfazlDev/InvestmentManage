using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.BusinessLogic.Services.CalculateProfit.Class;
using InvestmentManage.BusinessLogic.Services.CalculateProfit.Interface;

namespace InvestmentManage.BusinessLogic.Services.FacadPattern
{
    public class CalProfit
    {
		private ICalMothProfitByYear _mothProfitList;

		public ICalMothProfitByYear MothProfitList
		{
			get { return _mothProfitList = _mothProfitList ?? new CalMothProfitByYear(); }
		}

	}
}
