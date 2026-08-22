//using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Services;

public class ClientIconService(IconUrlProvider iconUrlProvider, HttpClient httpClient /*, ResourceAssetCollection assets*/)
    : IIconService
{
    private readonly IconUrlProvider _iconUrlProvider = iconUrlProvider;
    private readonly HttpClient _httpClient = httpClient;
    //private readonly ResourceAssetCollection _assets = assets;

    public async Task<string> GetIconMarkup(string iconId)
    {
        string url = _iconUrlProvider.GetIconUrl(iconId);
        //string assetKey = _iconUrlProvider.GetIconUrl(iconId);
        //string url = _assets[assetKey];
        string markup = await _httpClient.GetStringAsync(url);
        return markup;
    }

    public string[] GetIconNames(string searchTerm)
    {
        throw new NotImplementedException();
    }
}
