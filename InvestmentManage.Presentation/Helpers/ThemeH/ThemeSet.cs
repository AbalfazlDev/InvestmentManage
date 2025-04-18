using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialDesignColors;
using System.ComponentModel;
using MaterialDesignThemes.Wpf;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;
using static InvestmentManage.Domain.Model.EnumM;


namespace InvestmentManage.Presentation.Helpers.ThemeH
{
     public static class ThemeSet
    {
        private static ColorType _color = ColorType.Purple;
        private static ThemeModType _themeMod = ThemeModType.Light;

        public static void ChangeThemeColor(ColorType color)
        {
            _color = color;
            ResetTheme();
        }


        static public void ChangeDarkMode(ThemeModType mod)
        {
            _themeMod = mod;
            ResetTheme();
        }
       
        private static void ResetTheme()
        {
            var paletteHelper = new PaletteHelper();
            Theme themeT = paletteHelper.GetTheme();

            var uri = new Uri($"Resources/Theme/{_themeMod}{_color}Theme.xaml", UriKind.Relative);
            ResourceDictionary theme = new ResourceDictionary() { Source = uri };

            Application.Current.Resources.MergedDictionaries.Clear();
            
            Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary
            {
                Source = new Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign2.Defaults.xaml")
            });
            
            Application.Current.Resources.MergedDictionaries.Add(theme);

            themeT.SetBaseTheme(ConverThemeMod(_themeMod)); 

            themeT.SetPrimaryColor(ConvertColor(_color));

            themeT.SetSecondaryColor(Colors.Blue);

            themeT.PrimaryMid = new ColorPair(Colors.Brown, Colors.White);

            paletteHelper.SetTheme(themeT);
        }

        private static BaseTheme ConverThemeMod(ThemeModType mod)
        {
            return (mod == ThemeModType.Dark) ? BaseTheme.Dark : BaseTheme.Light;
        }
        public static Color ConvertColor(ColorType colorType)
        {
            switch (colorType)
            {
                case ColorType.Blue:
                    return Colors.Blue;
                case ColorType.DeepBlue:
                    return Colors.MidnightBlue;
                case ColorType.Purple:
                    return Colors.Purple;
                case ColorType.Orange:
                    return Colors.Orange;
                case ColorType.Red:
                    return Colors.Red;
                case ColorType.Cyan:
                    return Colors.Cyan;
                default:
                    return Colors.Black; 
            }
        }
    }
}
