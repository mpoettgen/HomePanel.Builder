using HomePanel.Builder.Client.Components;
using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HomePanel.Builder.Client.Pages;

public partial class PanelDesigner(IPanelDesignsProvider panelDesignsProvider, IDeviceListProvider deviceListProvider)
{
    private readonly IPanelDesignsProvider _panelDesignsProvider = panelDesignsProvider;
    private readonly IDeviceListProvider _deviceListProvider = deviceListProvider;

    [Parameter]
    public string DesignName { get; set; } = default!;
    public PanelDesign? PanelDesign { get; private set; } = default!;
    public List<PanelPage>? PanelPages => PanelDesign?.Pages;
    public PanelPage? CurrentPage { get; set; }
    public DeviceInfo? CurrentDevice { get; set; }
    public bool IsXYFlipped => PanelDesign?.Homepanel.Rotation is Rotation rotation && (rotation == Rotation.Rotate90Degrees || rotation == Rotation.Rotate270Degrees);
    public int Width => IsXYFlipped ? CurrentDevice?.Resolution.Height ?? 0 : CurrentDevice?.Resolution.Width ?? 0;
    public int Height => IsXYFlipped ? CurrentDevice?.Resolution.Width ?? 0 : CurrentDevice?.Resolution.Height ?? 0;
    public string Color { get; set; } = "black";

    protected async override Task OnInitializedAsync()
    {
        PanelDesign = await _panelDesignsProvider.LoadPanelDesign(DesignName);
        CurrentDevice = await _deviceListProvider.GetDeviceInfo(PanelDesign.Homepanel.Device);
        if (PanelPages is null)
            return;

        CurrentPage = PanelPages.FirstOrDefault();
    }

    private async Task HandlePageSelect(PageSelectEventArgs e)
    {
        CurrentPage = e.Page;
        await InvokeAsync(StateHasChanged);
    }

    protected bool IsCurrent(PanelPage page)
    {
        return page == CurrentPage;
    }
}
