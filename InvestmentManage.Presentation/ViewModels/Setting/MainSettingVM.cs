using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using InvestmentManage.Domain.Model;
using InvestmentManage.Domain.Model.Font;
using InvestmentManage.Domain.Model.Theme;
using InvestmentManage.Presentation.Helpers;
using InvestmentManage.Presentation.Helpers.Language;
using InvestmentManage.Presentation.Helpers.ThemeH;
using PropertyChanged;
using static InvestmentManage.Domain.Model.EnumM;
using static InvestmentManage.Domain.Model.MarketCategory.MarketTypeM;

namespace InvestmentManage.Presentation.ViewModels.Setting
{
    [AddINotifyPropertyChangedInterface]
    public class MainSettingVM : FontSizeModel
    {
        public ObservableCollection<FontSizeType> FontSizeItems { get; set; }
        public ObservableCollection<ColorThemeItemsM> ColorThemeItems { get; set; }
        public string LblFontSize { get; set; }
        public string LblLanguage { get; set; }
        public string LblColor { get; set; }
        public int FontSizeSlider { get; set; }

        public MainSettingVM()
        {
            ColorThemeItems = new ObservableCollection<ColorThemeItemsM>();
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
        public Action OnChangeColor { get; set; }
        public bool IsSliderFontSize { get; set; }
        public Action<int> OnFontSizeChanged { get; set; }
        public FontSizeType SelectedFontSize { get; set; } /*= FontSizeType.Medium;*/
        public ColorType SelectedColor { get; set; }
        public LanguageList SelectedLanguage { get; set; }


        public void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OnFontSizeChanged.Invoke(FontSizeSlider);
            SelectedFontSize = FontSizeType.Custom;
        }
        public void LB_FontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FontSizeType.Custom == SelectedFontSize)
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

        public void Lb_LanguageChanged_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnLanguageSelected.Invoke(SelectedLanguage);
        }
        
        public void Lb_ColorThemeChanged_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            //ListBox listbox = sender as ListBox;
            //ColorThemeItemsM selectedColor = (ColorThemeItemsM)listbox.SelectedItem;
            ThemeSet.ChangeThemeColor(SelectedColor);
            OnChangeColor();

        }

        public void Slider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OnFontSizeChanged.Invoke(FontSizeSlider);
            SelectedFontSize = FontSizeType.Custom;
        }


        public void Lb_ChangeFontSize_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (FontSizeType.Custom == SelectedFontSize)
                IsSliderFontSize = true;
            else
            {
                IsSliderFontSize = false;
                OnFontSizeSelected.Invoke(SelectedFontSize);
            }
        }

        public void ResetLanguage()
        {

            LblFontSize = LocalizationLanguage.GetString("FontSize");
            LblLanguage = LocalizationLanguage.GetString("Language");
            LblColor = LocalizationLanguage.GetString("Color");
            ColorThemeItems.Clear();
            foreach(ColorType type in Enum.GetValues(typeof(ColorType)))
            {
                ColorThemeItems.Add(new ColorThemeItemsM
                {
                    Color = type,
                    DisplayText = LocalizationLanguage.GetString($"{type}"),
                });
            }
        }
    }
}
