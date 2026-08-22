using HomePanel.Builder.Client.Services;

namespace HomePanel.Builder.Services;

public class ServerIconService(IEnumerable<IIconProvider> iconProviders) : IIconService
{
    private readonly IEnumerable<IIconProvider> _iconProviders = iconProviders;

    public async Task<string> GetIconMarkup(string iconId)
    {
        string[] strings = iconId.Split(':');
        if (strings.Length != 2)
            throw new InvalidOperationException($"Invalid icon id: {iconId}");

        IIconProvider iconProvider = _iconProviders.Single(ip => ip.Source == strings[0]);
        return await iconProvider.GetIconMarkup(strings[1]);
    }

    public string[] GetIconNames(string searchTerm)
    {
        throw new NotImplementedException();
    }
}
