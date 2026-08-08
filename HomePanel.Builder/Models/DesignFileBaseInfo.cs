namespace HomePanel.Builder.Models;

/// <summary>
/// Represents the base information of a design file, including the HomePanel information.
/// This is the information typically displayed for each design in the HomePanel Builder application.
/// </summary>
public class DesignFileBaseInfo
{
    public required HomePanelInfo Homepanel { get; set; }
}
