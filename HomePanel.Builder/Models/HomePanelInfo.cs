namespace HomePanel.Builder.Models;

/// <summary>
/// Represents the information about a HomePanel device.
/// </summary>
public class HomePanelInfo
{
    /// <summary>
    /// Gets or sets the name of the HomePanel device.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the friendly name of the HomePanel device.
    /// </summary>
    public string? FriendlyName { get; set; }

    /// <summary>
    /// Gets or sets the device identifier for the HomePanel device.
    /// </summary>
    public required string Device { get; set; }
}
