using HomePanel.Builder.Models;

namespace HomePanel.Builder.Client.Models;

public class PanelDesign : PanelDesignBase
{
    public List<PanelPage>? Pages { get; set; } = [];
}
