using System.ComponentModel.DataAnnotations;

namespace HomePanel.Builder.Client.Models;

public class NewPanelInfo
{
    [Required]
    [StringLength(64, MinimumLength = 1)]
    public string? FriendlyName { get; set; }
    [Required]
    [StringLength(32)]
    public string? Name { get; set; }
    [Required]
    public string? DeviceId { get; set; }
}
