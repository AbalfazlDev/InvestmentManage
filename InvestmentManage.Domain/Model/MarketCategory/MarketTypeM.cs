using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManage.Domain.Model.MarketCategory
{
    public class MarketTypeM
    {
        private string _txtSetting = "تنظیمات";

        public enum MarketType
        {
            [Description("بورس اوراق بهادار")]
            StockExchange,

            [Description("فرابورس")]
            OTCMarket,

            [Description("بورس کالا")]
            CommoditiesExchange,

            [Description("بورس انرژی")]
            EnergyExchange,

            [Description("تنظیمات")]
            Setting,

            
        }
    }
}
