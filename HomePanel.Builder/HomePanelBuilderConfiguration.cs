namespace HomePanel.Builder;

public class HomePanelBuilderConfiguration
{
    public string? EsphomeConfigPath { get; internal set; }

    public string GetDesignsPath()
    {
        if (string.IsNullOrEmpty(EsphomeConfigPath))
        {
            throw new InvalidOperationException("EsphomeConfigPath is not configured.");
        }
        return Path.Combine(Path.GetFullPath(EsphomeConfigPath), ".home-panel-builder");
    }
}
