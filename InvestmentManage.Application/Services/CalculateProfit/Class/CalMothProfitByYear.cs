using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvestmentManage.BusinessLogic.Services.CalculateProfit.Interface;

namespace InvestmentManage.BusinessLogic.Services.CalculateProfit.Class
{
    public class CalMothProfitByYear : ICalMothProfitByYear
    {

        public List<double> Execute(double initialAmount, double yearRate, int numberPeriod)
        {
            double profitInYear = (initialAmount * yearRate) / 100;
            double profitEveryPeriod = profitInYear / numberPeriod;
            profitEveryPeriod = Math.Floor(profitEveryPeriod / 1000) * 1000; // rounded amount
            List<double> profitPeriod = new List<double>();
            profitPeriod.AddRange(Enumerable.Repeat(profitEveryPeriod, numberPeriod));
            return profitPeriod;
        }
    }
}
