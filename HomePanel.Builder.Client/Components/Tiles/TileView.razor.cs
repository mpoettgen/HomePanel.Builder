using System.Drawing;
using HomePanel.Builder.Client.Models.Tiles;
using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Components.Tiles;

public partial class TileView
{
    [Parameter]
    public Tile Tile { get; set; } = null!;

    [Parameter]
    public float CellWidth { get; set; }

    [Parameter]
    public float CellHeight { get; set; }

    private bool HaveName => !string.IsNullOrEmpty(Tile.Name);
    private bool HaveValue => !string.IsNullOrEmpty(Tile.Value);
    private bool HaveIcon => !string.IsNullOrEmpty(Tile.Icon);

    private string TileType => $"{(HaveName ? "n" : "")}{(HaveValue ? "v" : "")}{(HaveIcon ? "i" : "")}";

    RectangleF TileRect => new(Tile.Cell.X * CellWidth, Tile.Cell.Y * CellHeight, Tile.Size.Width * CellWidth, Tile.Size.Height * CellHeight);
}
