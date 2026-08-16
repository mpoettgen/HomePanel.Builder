using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Components;

public partial class Icon
{
    [Parameter]
    public string? Id { get; set; } = default;

    private string? Path { get; set; }

    protected override Task OnInitializedAsync()
    {
        return base.OnInitializedAsync();
    }
}
