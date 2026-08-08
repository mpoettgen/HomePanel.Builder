using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using HomePanel.Builder.Models;
using Microsoft.Extensions.Options;
using SharpYaml;

namespace HomePanel.Builder.Services;

public class ServerPanelDesignsProvider(IOptions<HomePanelBuilderConfiguration> options) : IPanelDesignsProvider
{
    private readonly HomePanelBuilderConfiguration _config = options.Value;

    private async IAsyncEnumerable<DesignInfo> GetDesignFiles()
    {
        string designsPath = _config.GetDesignsPath();
        if (!Directory.Exists(designsPath))
            yield break;

        string? configPath = Path.GetDirectoryName(designsPath);
        if (configPath is null)
            yield break;

        foreach (string designFile in Directory.EnumerateFiles(designsPath, "*.design.yaml"))
        {
            string designFileContent = await File.ReadAllTextAsync(designFile);
            DesignFileBaseInfo reducedDesignFile = YamlSerializer.Deserialize(designFileContent, DesignFileYamlContext.Default.DesignFileBaseInfo)
                ?? throw new InvalidOperationException("Couldn't read design file!");

            HomePanelInfo homePanelInfo = reducedDesignFile.Homepanel
                ?? throw new InvalidOperationException("Couldn't read home panel info!");

            string identitier = Path.GetFileNameWithoutExtension(
                Path.GetFileNameWithoutExtension(designFile)
                );
            string configFile = Path.Combine(configPath, $"{identitier}.yaml");
            yield return new DesignInfo
            {
                Identifier = identitier,
                Name = homePanelInfo.FriendlyName ?? identitier,
                Design = Path.GetFileName(designFile),
                DesignFile = designFile,
                Config = Path.GetFileName(configFile),
                ConfigFile = configFile,
                Device = homePanelInfo.Device
            };
        }
    }

    public async Task<DesignInfo[]> GetDesignInfos()
    {
        List<DesignInfo> designInfos = [];
        await foreach (var designInfo in GetDesignFiles())
        {
            designInfos.Add(designInfo);
        }
        return [.. designInfos];
    }
}
