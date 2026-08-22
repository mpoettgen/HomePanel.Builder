namespace HomePanel.Builder.Models;

public class MdiIcon
{
    public Guid Id { get; set; }
    public Guid BaseIconId { get; set; }
    public required string Name { get; set; }
    public string[] Aliases { get; set; } = [];
}
