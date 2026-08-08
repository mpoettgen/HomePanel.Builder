using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

public interface IPanelDesignsProvider
{
    Task<DesignInfo[]> GetDesignInfos();
}
