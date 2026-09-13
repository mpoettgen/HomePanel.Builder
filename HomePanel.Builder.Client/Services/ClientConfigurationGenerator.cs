namespace HomePanel.Builder.Client.Services;

public class ClientConfigurationGenerator(HttpClient http) : IConfigurationGenerator
{
    private readonly HttpClient _http = http;

    public async Task Generate(string name)
    {
        HttpResponseMessage response = await _http.PostAsync($"/api/designs/{name}/generate", null);
        response.EnsureSuccessStatusCode();
    }
}
