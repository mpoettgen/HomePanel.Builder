using System.Net.Http.Json;
using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

public class ClientPanelDesignsProvider(HttpClient http) : IPanelDesignsProvider
{
    private readonly HttpClient _http = http;

    public async Task<DesignInfo> AddNewPanel(NewPanelInfo newPanelInfo)
    {
        HttpResponseMessage response = await _http.PostAsJsonAsync("/api/designs", newPanelInfo);
        return await response.Content.ReadFromJsonAsync<DesignInfo>()
            ?? throw new InvalidOperationException("Failed to add new panel.");
    }

    public async Task<DesignInfo[]> GetDesignInfos()
    {
        return await _http.GetFromJsonAsync<DesignInfo[]>("/api/designs")
            ?? throw new InvalidOperationException("Failed to fetch panel designs.");
    }

    public async Task<PanelDesign> LoadPanelDesign(string name)
    {
        PanelDesign panelDesign = await _http.GetFromJsonAsync<PanelDesign>($"/api/designs/{name}")
            ?? throw new InvalidOperationException("Failed to load panel design.");
        return panelDesign;
    }
}
