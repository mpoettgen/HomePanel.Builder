using HomePanel.Builder.Client.Services;
using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Components;

public partial class Icon(IIconService iconService)
{
    private readonly IIconService _iconService = iconService;

    [Parameter]
    public string? Id { get; set; } = default;

    [Parameter]
    public string? Alt { get; set; } = default;

    private MarkupString? Markup { get; set; }

    protected override async Task OnInitializedAsync()
    {
        if (Id is null)
            return;
        Markup = new MarkupString(
            await _iconService.GetIconMarkup(Id)
            );
    }
}
