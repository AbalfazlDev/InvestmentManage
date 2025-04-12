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


namespace InvestmentManage.Presentation.Helpers.ThemeH
{
     public class ThemeSet
    {
        public ThemeSet()
        {

        }
        static public void ChangeThemeColor(Color colorPrimary, Color colorSecond)
        {
            var paletteHelper = new PaletteHelper();
            //Retrieve the app's existing theme
            Theme theme = paletteHelper.GetTheme();

            //Change the base theme to Dark
            //theme.SetBaseTheme(BaseTheme.Dark);
            //or theme.SetBaseTheme(Theme.Light);

            //Change all of the primary colors to Red
            theme.SetPrimaryColor(colorPrimary);

            //Change all of the secondary colors to Blue
            theme.SetSecondaryColor(colorSecond);

            //You can also change a single color on the theme, and optionally set the corresponding foreground color
            //theme.PrimaryMid = new ColorPair(Colors.Brown, Colors.White);

            //Change the app's current theme
            paletteHelper.SetTheme(theme);
        }

        static public void ChangeDarkMode(bool isDark)
        {

            if (isDark)
            {
                var uri = new Uri("Resources/Theme/DarkPurpleTheme.xaml", UriKind.Relative);
                ResourceDictionary theme = new ResourceDictionary() { Source = uri };

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(theme);
            }
            else
            {
                var uri = new Uri("Resources/Theme/LightPurpleTheme.xaml", UriKind.Relative);
                ResourceDictionary theme = new ResourceDictionary() { Source = uri };

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(theme);
            }
        }


    }
}
