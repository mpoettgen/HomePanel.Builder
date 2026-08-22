using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

public interface IDeviceListProvider
{
    public Task<DeviceInfo?> GetDeviceInfo(string deviceId);
    public Task<DeviceInfo[]> GetDeviceList();
}
