using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Pages;

public partial class PanelDesigner(
    IPanelDesignsProvider panelDesignsProvider,
    IConfigurationGenerator configurationGenerator,
    IDeviceListProvider deviceListProvider
    )
{
    private readonly IPanelDesignsProvider _panelDesignsProvider = panelDesignsProvider;
    private readonly IConfigurationGenerator _configurationGenerator = configurationGenerator;
    private readonly IDeviceListProvider _deviceListProvider = deviceListProvider;

    [Parameter]
    public string DesignName { get; set; } = default!;
    public PanelDesign? PanelDesign { get; private set; } = default!;
    public List<PanelPage>? PanelPages => PanelDesign?.Pages;
    public PanelPage? CurrentPage { get; set; }
    public DeviceInfo? Device { get; set; }

    protected async override Task OnInitializedAsync()
    {
        PanelDesign = await _panelDesignsProvider.LoadPanelDesign(DesignName);
        Device = await _deviceListProvider.GetDeviceInfo(PanelDesign.Homepanel.Device);
        if (PanelPages is null)
            return;

        CurrentPage = PanelPages.FirstOrDefault();
    }

    private async Task HandlePageSelect(PageSelectEventArgs e)
    {
        CurrentPage = e.Page;
        await InvokeAsync(StateHasChanged);
    }

    private async Task GenerateConfiguration()
    {
        await _configurationGenerator.Generate(DesignName);
    }

    protected bool IsCurrent(PanelPage page)
    {
        return page == CurrentPage;
    }
}
