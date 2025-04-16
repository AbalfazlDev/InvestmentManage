using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using InvestmentManage.Domain.Model;
using InvestmentManage.Presentation.Helpers;
using InvestmentManage.Presentation.Helpers.Language;
using static InvestmentManage.Domain.Model.EnumM;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.ViewModels.Setting
{
    public class MainSettingVM : FontSizeModel
    {
        public ObservableCollection<FontSizeType> FontSizeItems { get; set; }
        public string LblFontSize { get; set; }
        public string LblLanguage { get; set; }
        //private double _fontSizeSlider;

        //public double FontSizeSlider
        //{
        //    get { return _fontSizeSlider; }
        //    set
        //    {
        //        _fontSizeSlider = value;
        //        OnFontSizeChanged.Invoke((int)FontSizeSlider);
        //    }
        //}
        public int FontSizeSlider { get; set; }
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
        public bool IsSliderFontSize { get; set; }
        public Action<int> OnFontSizeChanged { get; set; }
        public FontSizeType SelectedFontSize { get; set; } = FontSizeType.Medium;

        public LanguageList SelectedLanguage { get; set; }


        public void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OnFontSizeChanged.Invoke(FontSizeSlider);
            SelectedFontSize = FontSizeType.Custom;
        }
        public void LB_FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FontSizeType.Custom == SelectedFontSize)
                IsSliderFontSize = true;
            else
            {
                IsSliderFontSize = false;
                OnFontSizeSelected.Invoke(SelectedFontSize);
            }
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
