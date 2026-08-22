namespace HomePanel.Builder.Client.Models;

/// <summary>
/// Represents the information about a HomePanel device.
/// </summary>
public class PanelInfo
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

    /// <summary>
    /// Gets or sets the rotation of the HomePanel device.
    /// </summary>
    public Rotation Rotation { get; set; } = Rotation.None;
}
