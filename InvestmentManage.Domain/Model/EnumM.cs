using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentManage.Domain.Model
{
    public class EnumM
    {
        public enum SettingItems
        {
            Font,
            Theme,
            Databases,
            Language
        }
        public enum LanguageList
        {
            Farsi,
            English
        }

        public enum FontSizeType
        {
            Small,
            Medium,
            Large,
            ExtraLarge
        }

        public enum MenuType
        {
            Home,
            [Description("بورس اوراق بهادار")]
            StockExchange,

            [Description("فرابورس")]
            OTCMarket,

            [Description("بورس کالا")]
            CommoditiesExchange,

            [Description("بورس انرژی")]
            EnergyExchange,
            Settings

        }

    }
}
