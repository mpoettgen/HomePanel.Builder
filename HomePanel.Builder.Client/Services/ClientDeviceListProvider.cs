using System.Net.Http.Json;
using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

public class ClientDeviceListProvider(HttpClient http) : IDeviceListProvider
{
    private readonly HttpClient _http = http;

    public Task<DeviceInfo[]> GetDeviceList()
    {
        return _http.GetFromJsonAsync<DeviceInfo[]>("/api/devices")
            .ContinueWith(task =>
            {
                if (!task.IsCompletedSuccessfully || task.Result is null)
                {
                    // Handle the error
                    Console.WriteLine($"Error fetching device list: {task.Exception?.Message ?? "Unexpected result!"}");
                    return [];
                }

                return task.Result;
            });

    }
}
