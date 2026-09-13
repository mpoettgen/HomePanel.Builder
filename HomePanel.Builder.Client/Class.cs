using System.Globalization;

namespace HomePanel.Builder.Client;

public static class HelperExtensions
{
    public static string ToValue(this float value)
    {
        return string.Create(CultureInfo.InvariantCulture, $"{value:F1}");
    }
    public static string ToPixel(this float value)
    {
        return string.Create(CultureInfo.InvariantCulture, $"{value:F1}px");
    }
}
