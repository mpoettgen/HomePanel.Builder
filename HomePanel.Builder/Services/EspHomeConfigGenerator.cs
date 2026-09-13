using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;

namespace HomePanel.Builder.Services;

public class EspHomeConfigGenerator(ServerPanelDesignsProvider panelDesignsProvider) : IConfigurationGenerator
{
    private readonly ServerPanelDesignsProvider _panelDesignsProvider = panelDesignsProvider;

    public async Task Generate(string name)
    {
        PanelDesign panelDesign = await _panelDesignsProvider.LoadPanelDesign(name);
        string configFilePath = _panelDesignsProvider.GetConfigurationFilePath(name);


    }
}
