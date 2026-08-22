namespace HomePanel.Builder.Client.Models;

public class PanelPage
{
    public required string Id { get; set; }
    public bool IsHomePage { get; set; } = false;
    public bool IsIdlePage { get; set; } = false;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
