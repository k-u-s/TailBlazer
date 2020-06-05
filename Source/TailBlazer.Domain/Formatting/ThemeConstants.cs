using System.Windows.Media;

namespace TailBlazer.Domain.Formatting
{
    public static class ThemeConstants
    {
        public const string LightThemeAccent = "indigo";
        public const string DarkThemeAccent = "yellow";

        public static Color LightThemeAccentColor = System.Windows.Media.Colors.Indigo;
        public static Color DarkThemeAccentColor = System.Windows.Media.Colors.Yellow;

        public static readonly string[] Themes = {
            "yellow",
            "amber",
            "lightgreen",
            "green",
            "lime",
            "teal",
            "cyan",
            "lightblue",
            "blue",
            "indigo",
            "orange",
            "deeporange",
            "pink",
            "red",
            "purple",
            "deeppurple",
            "gray"
        };

        public static string GetAccentColorText(this Theme theme)
        {
            return theme == Theme.Dark ? DarkThemeAccent : LightThemeAccent;
        }

        public static Color GetAccentColor(this Theme theme)
        {
            return theme == Theme.Dark ? DarkThemeAccentColor : LightThemeAccentColor;
        }
    }
}