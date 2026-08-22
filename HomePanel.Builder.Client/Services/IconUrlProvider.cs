namespace HomePanel.Builder.Client.Services;

public class IconUrlProvider
{
    public string GetIconUrl(string iconId)
    {
        string[] strings = iconId.Split(':');
        if (strings.Length != 2)
            throw new InvalidOperationException($"Invalid icon id: {iconId}");

        return strings[0] switch
        {
            "mdi" => $"icons/mdi/svg/{strings[1]}.svg",
            _ => throw new InvalidOperationException($"Invalid icon source: {strings[0]}"),
        };
    }
}
