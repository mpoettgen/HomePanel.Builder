using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using HomePanel.Builder.Models;
using Microsoft.Extensions.Options;
using SharpYaml;

namespace HomePanel.Builder.Services;

public class ServerPanelDesignsProvider(IOptions<HomePanelBuilderConfiguration> options) : IPanelDesignsProvider
{
    private readonly HomePanelBuilderConfiguration _config = options.Value;

    public string DesignsPath
    {
        get
        {
            string designsPath = _config.GetDesignsPath();
            if (!Directory.Exists(designsPath))
                Directory.CreateDirectory(designsPath);

            return designsPath;
        }
    }

    public string ConfigsPath
    {
        get
        {
            string configsPath = _config.GetEsphomeConfigPath();
            if (!Directory.Exists(configsPath))
                throw new InvalidOperationException($"Configs path '{configsPath}' does not exist.");
            return configsPath;
        }
    }

    private async IAsyncEnumerable<DesignInfo> GetDesignFiles()
    {
        foreach (string designFile in Directory.EnumerateFiles(DesignsPath, "*.design.yaml"))
        {
            string designFileContent = await File.ReadAllTextAsync(designFile);
            DesignFileBaseInfo reducedDesignFile = YamlSerializer.Deserialize(designFileContent, DesignFileYamlContext.Default.DesignFileBaseInfo)
                ?? throw new InvalidOperationException($"Couldn't read design file '{designFile}'!");

            HomePanelInfo homePanelInfo = reducedDesignFile.Homepanel
                ?? throw new InvalidOperationException($"Couldn't read home panel info for design file '{designFile}'!");

            // strip both extensions to get the name (e.g., "my_panel.design.yaml" -> "my_panel")
            string name = Path.GetFileNameWithoutExtension(
                Path.GetFileNameWithoutExtension(designFile)
                );
            string configFile = Path.Combine(ConfigsPath, $"{name}.yaml");
            yield return new DesignInfo
            {
                Name = name,
                FriendlyName = homePanelInfo.FriendlyName ?? name,
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

    public async Task<DesignInfo> AddNewPanel(NewPanelInfo newPanelInfo)
    {
        string name = newPanelInfo.Name
            ?? throw new InvalidOperationException("New panel name cannot be null!");
        string friendlyName = newPanelInfo.FriendlyName ?? name;
        string deviceId = newPanelInfo.DeviceId
            ?? throw new InvalidOperationException("Need to select a device!");

        string newDesignFileName = $"{newPanelInfo.Name}.design.yaml";
        string newDesignFilePath = Path.Combine(DesignsPath, newDesignFileName);
        if (File.Exists(newDesignFilePath))
            throw new InvalidOperationException($"Design file '{newDesignFilePath}' already exists.");

        string newConfigFileName = $"{newPanelInfo.Name}.yaml";
        string newConfigFilePath = Path.Combine(ConfigsPath, newConfigFileName);
        if (File.Exists(newConfigFilePath))
            throw new InvalidOperationException($"Config file '{newConfigFilePath}' already exists.");

        DesignFileBaseInfo designFile = new()
        {
            Homepanel = new HomePanelInfo
            {
                Name = name,
                FriendlyName = friendlyName,
                Device = deviceId,
            }
        };

        using (MemoryStream memoryStream = new())
        {
            YamlSerializer.Serialize(memoryStream, designFile, DesignFileYamlContext.Default);
            memoryStream.Position = 0;  // rewind the stream to the beginning before copying it to the file

            using FileStream file = File.Create(newDesignFilePath);
            await memoryStream.CopyToAsync(file);
            await file.FlushAsync();
        }

        return new DesignInfo
        {
            Name = name,
            FriendlyName = friendlyName,
            Design = newDesignFileName,
            DesignFile = newDesignFilePath,
            Config = newConfigFileName,
            ConfigFile = newConfigFilePath,
            Device = deviceId
        };
    }
}
