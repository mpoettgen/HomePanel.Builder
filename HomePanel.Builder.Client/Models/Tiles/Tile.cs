using System.Drawing;

namespace HomePanel.Builder.Client.Models.Tiles;

public class Tile
{
    public Point Cell { get; set; }
    public Size Size { get; set; }
    public virtual string? Name { get; set; }
    public virtual string? Value { get; set; }
    public virtual string? Icon { get; set; }
}
