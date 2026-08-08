using System.Net.Http.Json;
using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

public class ClientPanelDesignsProvider(HttpClient http) : IPanelDesignsProvider
{
    private readonly HttpClient _http = http;

    public Task<DesignInfo[]> GetDesignInfos()
    {
        return _http.GetFromJsonAsync<DesignInfo[]>("/api/designs")
            .ContinueWith(task =>
            {
                if (!task.IsCompletedSuccessfully || task.Result is null)
                {
                    // Handle the error
                    Console.WriteLine($"Error fetching panel designs: {task.Exception?.Message ?? "Unexpected result!"}");
                    return [];
                }

                return task.Result;
            });
    }
}
