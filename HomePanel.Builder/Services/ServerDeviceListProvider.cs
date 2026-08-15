using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using SharpYaml;

namespace HomePanel.Builder.Services;

public class ServerDeviceListProvider : IDeviceListProvider
{
    public async Task<DeviceInfo[]> GetDeviceList()
    {
        string deviceListFilePath = Path.Combine(AppContext.BaseDirectory, "Devices", "devices.yaml");

        if (!File.Exists(deviceListFilePath))
            throw new FileNotFoundException($"Device list file not found: {deviceListFilePath}");

        string deviceListContent = await File.ReadAllTextAsync(deviceListFilePath);
        DeviceList? deviceList = YamlSerializer.Deserialize(deviceListContent, DeviceListYamlContext.Default.DeviceList);

        return (deviceList ?? throw new InvalidOperationException("Couldn't read device list!")).Devices;
    }
}
