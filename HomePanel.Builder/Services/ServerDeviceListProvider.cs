using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using Microsoft.Extensions.FileProviders;
using SharpYaml;

namespace HomePanel.Builder.Services;

public sealed class ServerDeviceListProvider : IDeviceListProvider, IDisposable
{
    private readonly PhysicalFileProvider _fileProvider;

    public ServerDeviceListProvider()
    {
        _fileProvider = new PhysicalFileProvider(Path.Combine(AppContext.BaseDirectory, "Devices"));
    }

    public Action? OnDeviceListChanged { get; internal set; }

    public void Dispose()
    {
        _fileProvider?.Dispose();
    }

    public async Task<DeviceInfo?> GetDeviceInfo(string deviceId)
    {
        throw new NotImplementedException("Use the CachingDeviceListProvider to obtain device information.");
    }

    public async Task<DeviceInfo[]> GetDeviceList()
    {
        string deviceListFilePath = Path.Combine(AppContext.BaseDirectory, "Devices", "devices.yaml");

        if (!File.Exists(deviceListFilePath))
            throw new FileNotFoundException($"Device list file not found: {deviceListFilePath}");

        string deviceListContent = await File.ReadAllTextAsync(deviceListFilePath);
        DeviceList? deviceList = YamlSerializer.Deserialize(deviceListContent, DeviceListYamlContext.Default.DeviceList);

        return (deviceList ?? throw new InvalidOperationException("Couldn't read device list!")).Devices;
    }

    internal void WatchDeviceList()
    {
        _fileProvider.Watch("devices.yaml").RegisterChangeCallback(state =>
        {
            if (state is not ServerDeviceListProvider provider)
                return;
            provider.OnDeviceListChanged?.Invoke();
            provider.WatchDeviceList(); // Re-register the callback to continue watching for changes
        }, this);
    }
}
