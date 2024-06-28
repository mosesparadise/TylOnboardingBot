using MudBlazor;

namespace TylOnboardingBot.Components.Layout;

public partial class BotLayout
{
    private bool _isDarkMode;
    private readonly MudTheme _currentTheme = CurrentTheme();
    
    private static MudTheme CurrentTheme()
    {
        var defaultTheme = new MudTheme();
        var defaultDarkPallete = defaultTheme.PaletteDark;
        var defaultLightPallete = defaultTheme.Palette;

        //Dark 
        defaultDarkPallete.Dark = "#202020";
        defaultDarkPallete.Primary = "#F5F5F5";
        defaultDarkPallete.AppbarBackground = "#2A2A2A";
        defaultDarkPallete.DarkContrastText = "#F5F5F5";
        defaultDarkPallete.Background = "#121212";
        defaultDarkPallete.DrawerBackground = "#2A2A2A";
        defaultDarkPallete.Surface = "#2A2A2A";
        defaultDarkPallete.TextPrimary = "#ecf2f8";
        defaultDarkPallete.PrimaryContrastText = "161b22";
        defaultDarkPallete.AppbarText = "#F5F5F5";
        defaultDarkPallete.Tertiary = "#121212";
        defaultDarkPallete.HoverOpacity = .2;

        //Light
        defaultLightPallete.Primary = "#161b22";
        defaultLightPallete.PrimaryContrastText = "#EEEEEE";
        defaultLightPallete.AppbarText = "#EEEEEE";
        defaultLightPallete.TextPrimary = "#161b22";
        defaultLightPallete.AppbarBackground = "#58A6FF";
        defaultLightPallete.Tertiary = "#FFFFFF";

        return defaultTheme;
    }
}