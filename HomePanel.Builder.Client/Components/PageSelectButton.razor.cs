using HomePanel.Builder.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace HomePanel.Builder.Client.Components;

public partial class PageSelectButton
{
    public string Id { get; } = Guid.NewGuid().ToString();

    [Parameter]
    public PanelPage Page { get; set; } = default!;

    [Parameter]
    public bool IsCurrent { get; set; } = false;

    [Parameter]
    public EventCallback<PageSelectEventArgs> OnPageSelect { get; set; }

    private async Task HandleClick(MouseEventArgs e)
    {
        await OnPageSelect.InvokeAsync(new PageSelectEventArgs { Page = Page });
    }
}
