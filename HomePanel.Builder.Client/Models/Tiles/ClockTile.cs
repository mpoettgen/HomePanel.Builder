namespace HomePanel.Builder.Client.Models.Tiles;

public class ClockTile : Tile
{
    public ClockStyle Style { get; set; }

    public bool ShowSeconds { get; set; } = false;

    public enum ClockStyle
    {
        Digital24Hour,
        Digital12Hour,
        Analog
    }
}
