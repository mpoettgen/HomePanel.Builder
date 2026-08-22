using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Models;

/// <summary>
/// Represents the base information of a design file, including the HomePanel information.
/// This is the information typically displayed for each design in the HomePanel Builder application.
/// </summary>
public class PanelDesignBase
{
    public required PanelInfo Homepanel { get; set; }
}
