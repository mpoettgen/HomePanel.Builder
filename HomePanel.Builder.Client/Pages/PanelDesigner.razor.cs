using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Pages;

public partial class PanelDesigner
{
    [Parameter]
    public string DesignName { get; set; } = default!;
}
