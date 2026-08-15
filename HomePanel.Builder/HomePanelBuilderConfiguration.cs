namespace HomePanel.Builder;

public class HomePanelBuilderConfiguration
{
    public required string EsphomeConfigPath { get; set; }

    public string GetEsphomeConfigPath()
    {
        if (string.IsNullOrEmpty(EsphomeConfigPath))
            throw new InvalidOperationException("EsphomeConfigPath is not configured.");
        return Path.GetFullPath(EsphomeConfigPath);
    }

    public string GetDesignsPath()
    {
        string esphomeConfigPath = GetEsphomeConfigPath();
        return Path.Combine(esphomeConfigPath, ".home-panel-builder");
    }
}
