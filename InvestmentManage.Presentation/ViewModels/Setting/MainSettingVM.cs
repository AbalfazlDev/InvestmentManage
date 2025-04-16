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
using static InvestmentManage.Domain.Model.EnumM;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.ViewModels.Setting
{
    public class MainSettingVM : NotifyPropertyChanged
    {
        //private FontSizeType _selectedFontSize;

        //public FontSizeType SelectedFontSize
        //{
        //    get { return _selectedFontSize; }
        //    set
        //    {
        //        _selectedFontSize = value;
        //        OnPropertyChanged();
        //    }
        //}

        public ObservableCollection<FontSizeType> FontSizeItems { get; set; }
        public int AppFontSize { get; set; }

        private string _lblFontSize;

        public string LblFontSize
        {
            get { return _lblFontSize; }
            set
            {
                _lblFontSize = value;
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
            LVSettingItems = new ObservableCollection<SettingItems>(Enum.GetValues(typeof(SettingItems)).Cast<EnumM.SettingItems>());
            LBLanguage = new ObservableCollection<LanguageList>(Enum.GetValues(typeof(LanguageList)).Cast<EnumM.LanguageList>());
            SelectedLanguage = EnumM.LanguageList.English;
            FontSizeItems = new ObservableCollection<FontSizeType>(Enum.GetValues(typeof(FontSizeType)).Cast<EnumM.FontSizeType>());
            ResetLanguage();
        }
        public ObservableCollection<SettingItems> LVSettingItems { get; set; }
        public ObservableCollection<LanguageList> LBLanguage { get; set; }
        public Action<LanguageList> OnLanguageSelected { get; set; }
        public Action<FontSizeType> OnFontSizeSelected { get; set; }
        public FontSizeType SelectedFontSize { get; set; }
        private LanguageList _selectedLanguage;

        public LanguageList SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                _selectedLanguage = value;
                OnPropertyChanged(nameof(SelectedLanguage));
            }
        }
        public void LB_FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnFontSizeSelected.Invoke(SelectedFontSize);
        }

        public void LB_Language_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnLanguageSelected.Invoke(SelectedLanguage);
        }

        public void ResetLanguage()
        {
            LblFontSize = LocalizationLanguage.GetString("LblFontHead");
            LblLanguage = LocalizationLanguage.GetString("LblLanguage");
        }
    }
}
