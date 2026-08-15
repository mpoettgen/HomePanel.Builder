using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using Microsoft.Extensions.Caching.Memory;

namespace HomePanel.Builder.Services;

public class CachingDeviceListProvider(IMemoryCache memoryCache, ServerDeviceListProvider serverDeviceListProvider) : IDeviceListProvider
{
    private readonly IMemoryCache _memoryCache = memoryCache;
    private readonly ServerDeviceListProvider _serverDeviceListProvider = serverDeviceListProvider;

    public async Task<DeviceInfo[]> GetDeviceList()
    {
        return (await _memoryCache.GetOrCreateAsync("deviceList", async entry =>
        {
            return await _serverDeviceListProvider.GetDeviceList();
        })) ?? throw new InvalidOperationException("Should have created a value!");
    }
}
