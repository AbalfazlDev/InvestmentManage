using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using InvestmentManage.Presentation.Helpers;
using InvestmentManage.Presentation.Helpers.Language;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.ViewModels.Setting
{
    public class MainSettingVM : NotifyPropertyChanged
    {
        private string _lblFontHead;

        public string LblFontHead
        {
            get { return _lblFontHead; }
            set
            {
                _lblFontHead = value;
                OnPropertyChanged();
            }
        }
        private string _lblLanguage;

        public string LblLanguage
        {
            get { return _lblLanguage; }
            set
            {
                _lblLanguage = value;
                OnPropertyChanged();
            }
        }

        public MainSettingVM()
        {
            LVSettingItems = new ObservableCollection<SettingItems>(Enum.GetValues(typeof(SettingItems)).Cast<SettingItems>());
            ResetLanguage();
        }
        public ObservableCollection<SettingItems> LVSettingItems { get; set; }

        public enum SettingItems
        {
            Font,
            Theme,
            Databases,
            Language
        }

        public void ResetLanguage()
        {
            LblFontHead = LocalizationManager.GetString("LblFontHead");
            LblLanguage = LocalizationManager.GetString("LblLanguage");
        }
    }
}
