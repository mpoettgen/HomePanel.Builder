namespace HomePanel.Builder.Client.Models;

/// <summary>
/// Represents information about a panel design, including its name, friendly name, design, and configuration.
/// </summary>
public class DesignInfo
{
    public required string Name { get; set; }
    public required string FriendlyName { get; set; }
    public required string Design { get; set; }
    public required string DesignFile { get; set; }
    public required string Config { get; set; }
    public required string ConfigFile { get; set; }
    public required string Device { get; set; }
}
