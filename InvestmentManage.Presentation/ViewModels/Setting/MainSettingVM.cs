using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Markup;
using InvestmentManage.Domain.Model;
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
            LVSettingItems = new ObservableCollection<EnumM.SettingItems>(Enum.GetValues(typeof(EnumM.SettingItems)).Cast<EnumM.SettingItems>());
            LBLanguage = new ObservableCollection<EnumM.LanguageList>(Enum.GetValues(typeof(EnumM.LanguageList)).Cast<EnumM.LanguageList>());
            SelectedLanguage = EnumM.LanguageList.English;
            ResetLanguage();
        }
        public ObservableCollection<EnumM.SettingItems> LVSettingItems { get; set; }
        public ObservableCollection<EnumM.LanguageList> LBLanguage { get; set; }
        public Action<EnumM.LanguageList> OnLanguageSelected { get; set; }
        private EnumM.LanguageList _selectedLanguage;

        public EnumM.LanguageList SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }


        public void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnLanguageSelected.Invoke(SelectedLanguage);
        }

        public void ResetLanguage()
        {
            LblFontHead = LocalizationManager.GetString("LblFontHead") + " : ";
            LblLanguage = LocalizationManager.GetString("LblLanguage") + " : ";
        }
    }
}
