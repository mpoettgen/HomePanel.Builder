using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using Microsoft.Extensions.Caching.Memory;

namespace HomePanel.Builder.Services;

public class CachingDeviceListProvider : IDeviceListProvider
{
    private const string s_cacheKey = "deviceList";
    private readonly IMemoryCache _memoryCache;
    private readonly ServerDeviceListProvider _serverDeviceListProvider;

    public CachingDeviceListProvider(IMemoryCache memoryCache, ServerDeviceListProvider serverDeviceListProvider)
    {
        _memoryCache = memoryCache;
        _serverDeviceListProvider = serverDeviceListProvider;
        _serverDeviceListProvider.OnDeviceListChanged += DeviceListChanged;
        _serverDeviceListProvider.WatchDeviceList();
    }

    private void DeviceListChanged()
    {
        _memoryCache.Remove(s_cacheKey);
    }

    public async Task<DeviceInfo?> GetDeviceInfo(string deviceId)
    {
        DeviceInfo[] deviceList = await GetDeviceList();
        return deviceList.FirstOrDefault(d => d.Id == deviceId);
    }

    public async Task<DeviceInfo[]> GetDeviceList()
    {
        return (await _memoryCache.GetOrCreateAsync(s_cacheKey, async entry =>
        {
            return await _serverDeviceListProvider.GetDeviceList();
        })) ?? throw new InvalidOperationException("Should have created a value!");
    }
}
