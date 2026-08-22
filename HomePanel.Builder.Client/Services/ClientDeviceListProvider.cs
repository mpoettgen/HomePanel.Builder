using System.Net.Http.Json;
using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

public class ClientDeviceListProvider(HttpClient http) : IDeviceListProvider
{
    private readonly HttpClient _http = http;

    public async Task<DeviceInfo?> GetDeviceInfo(string deviceId)
    {
        return await _http.GetFromJsonAsync<DeviceInfo>($"/api/devices/{deviceId}");
    }

    public async Task<DeviceInfo[]> GetDeviceList()
    {
        return await _http.GetFromJsonAsync<DeviceInfo[]>("/api/devices") ?? [];
    }
}
