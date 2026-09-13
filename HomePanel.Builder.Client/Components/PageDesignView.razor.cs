using HomePanel.Builder.Client.Models;
using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Components;

public partial class PageDesignView
{
    [Parameter]
    public PanelDesign Design { get; set; } = default!;
    [Parameter]
    public PanelPage Page { get; set; } = default!;
    [Parameter]
    public DeviceInfo Device { get; set; } = default!;
    [Parameter]
    public bool DesignMode { get; set; } = true;

    public bool IsXYFlipped => Design.Homepanel.Rotation is Rotation rotation && (rotation == Rotation.Rotate90Degrees || rotation == Rotation.Rotate270Degrees);
    public int Width => IsXYFlipped ? Device.Resolution.Height : Device.Resolution.Width;
    public int Height => IsXYFlipped ? Device.Resolution.Width : Device.Resolution.Height;
    public int Columns => IsXYFlipped ? Device.BaseGrid.Height : Device.BaseGrid.Width;
    public int Rows => IsXYFlipped ? Device.BaseGrid.Width : Device.BaseGrid.Height;
    public float CellWidth => Width * 1.0f / Columns;
    public float CellHeight => Height * 1.0f / Rows;
    public string Color { get; set; } = "black";
}
