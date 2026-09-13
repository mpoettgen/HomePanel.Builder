using System.Drawing;

namespace HomePanel.Builder.Client.Models;

public class DeviceInfo
{
    /// <summary>
    /// The Id of the device
    /// </summary>
    public required string Id { get; set; }
    /// <summary>
    /// The name of the device
    /// </summary>
    public required string Name { get; set; }
    /// <summary>
    /// A more elaborate name for the device
    /// </summary>
    public string MarketingName { get => field ?? Name; set; }
    /// <summary>
    /// The horizontal and vertical number of pixels in default orientation.
    /// </summary>
    public Size Resolution { get; set; } = new Size();
    /// <summary>
    /// The horizontal and vertical number of grid cells in default orientation.
    /// </summary>
    public Size BaseGrid { get; set; } = new Size();
    /// <summary>
    /// The default orientation (Portrait, Landscape or Square)
    /// </summary>
    public DisplayOrientation DefaultOrientation { get; set; }
}
