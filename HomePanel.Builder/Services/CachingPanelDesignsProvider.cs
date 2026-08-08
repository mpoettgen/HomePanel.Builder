using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using Microsoft.Extensions.Caching.Memory;

namespace HomePanel.Builder.Services;

public class CachingPanelDesignsProvider(IMemoryCache memoryCache, ServerPanelDesignsProvider serverPanelDesignsProvider) : IPanelDesignsProvider
{
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly ServerPanelDesignsProvider _serverPanelDesignsProvider = serverPanelDesignsProvider;

    public async Task<DesignInfo[]> GetDesignInfos()
    {
        return (await _memoryCache.GetOrCreateAsync("designInfos", async entry =>
        {
            return await _serverPanelDesignsProvider.GetDesignInfos();
        })) ?? throw new InvalidOperationException("Should have created a value!");
    }
}
