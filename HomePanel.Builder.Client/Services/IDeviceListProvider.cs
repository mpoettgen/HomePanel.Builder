using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

public interface IDeviceListProvider
{
    public Task<DeviceInfo[]> GetDeviceList();
}
