using System.Drawing;

namespace HomePanel.Builder.Client.Models;

public class DeviceInfo
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public string MarketingName { get => field ?? Name; set; }
    public Size Resolution { get; set; } = new Size();
    public DisplayOrientation DefaultOrientation { get; set; }
}
