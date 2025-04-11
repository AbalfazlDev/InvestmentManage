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


namespace InvestmentManage.Presentation.Helpers.ThemeH
{
    public class ThemeStateH
    {
        public void ChangeThemeColor(Color colorPrimary, Color colorSecond)
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

        private void darkMod(bool isDark)
        {
            var paletteHelper = new PaletteHelper();
            Theme theme = paletteHelper.GetTheme();
            if (isDark)
            {
                theme.SetBaseTheme(BaseTheme.Dark);
                theme.PrimaryMid = new ColorPair(Colors.Purple, Colors.White);

            }
            else
                theme.SetBaseTheme(BaseTheme.Light);

            paletteHelper.SetTheme(theme);
        }


    }
}
