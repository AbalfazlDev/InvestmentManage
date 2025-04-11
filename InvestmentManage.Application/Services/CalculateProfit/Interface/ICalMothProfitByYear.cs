using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManage.BusinessLogic.Services.CalculateProfit.Interface
{
    public interface ICalMothProfitByYear
    {
        public List<double> Execute(double initialAmount, double yearRate,int numberPeriod);
    }
}
