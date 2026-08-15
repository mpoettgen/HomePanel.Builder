using System.Text;
using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Client.Services;
using Microsoft.AspNetCore.Components;

namespace HomePanel.Builder.Client.Components;

public partial class AddPanelModal(IDeviceListProvider deviceListProvider, IPanelDesignsProvider panelDesignsProvider)
{
    private readonly IDeviceListProvider _deviceListProvider = deviceListProvider;
    private readonly IPanelDesignsProvider _panelDesignsProvider = panelDesignsProvider;

    [SupplyParameterFromForm]
    private NewPanelInfo? Model { get; set; } = default!;

    private DeviceInfo[]? Devices { get; set; } = default!;

    private string AutoName { get; set; } = string.Empty;

    private bool HaveEnoughInformation => Model is NewPanelInfo model
        && !string.IsNullOrEmpty(model.DeviceId)
        && !string.IsNullOrEmpty(model.Name)
        && !string.IsNullOrEmpty(model.FriendlyName);

    [Parameter]
    public EventCallback<DesignInfo> OnPanelAdded { get; set; }

    protected override void OnInitialized()
    {
        Model = new();
    }

    protected async Task ShowModal()
    {
        Model = new();
        Devices = await _deviceListProvider.GetDeviceList();
    }

    private async Task Submit()
    {
        if (Model == null)
            return;

        DesignInfo designInfo = await _panelDesignsProvider.AddNewPanel(Model);
        await OnPanelAdded.InvokeAsync(designInfo);

        Model = new();  // reset the model for next use
    }

    private void FriendlyNameChanging(ChangeEventArgs e)
    {
        if ((Model is null) || (e.Value is not string newValue))
            return;
        string newAutoName = AutoCreateNameFromInput(newValue);
        if ((Model.Name ?? string.Empty) == AutoName)
            Model.Name = newAutoName;
        AutoName = newAutoName;
    }

    private void NameChanging(ChangeEventArgs e)
    {
        if (e.Value is not string newValue)
            return;
        string newAutoName = AutoCreateNameFromInput(newValue);
        AutoName = newAutoName;
    }

    private static string AutoCreateNameFromInput(string input)
    {
        StringBuilder builder = new(input.Length);
        foreach (char c in input)
        {
            if (char.IsAsciiLetterLower(c)
                || char.IsAsciiDigit(c)
                || (c == '-')
                || (c == '_'))
            {
                builder.Append(c);
                continue;
            }

            if (char.IsAsciiLetterUpper(c))
            {
                builder.Append(char.ToLowerInvariant(c));
                continue;
            }

            if (c == ' ')
            {
                builder.Append('-');
                continue;
            }

            builder.Append(ReplaceAccentsAndUmlautsWithLowerAscii(c));
        }
        while ((builder.Length != 0) && ((builder[0] == '-') || (builder[0] == '_')))
            builder.Remove(0, 1);
        while ((builder.Length != 0) && ((builder[^1] == '-') || (builder[^1] == '_')))
            builder.Remove(builder.Length - 1, 1);
        return builder.ToString();
    }

    private static string ReplaceAccentsAndUmlautsWithLowerAscii(char c)
    {
        return c switch
        {
            // Umlauts
            'ä' or 'Ä' => "ae",
            'ö' or 'Ö' => "oe",
            'ü' or 'Ü' => "ue",
            'ß' => "ss",

            // Accented vowels
            'á' or 'À' or 'à' or 'Á' or 'â' or 'Â' or 'ã' or 'Ã' => "a",
            'é' or 'É' or 'è' or 'È' or 'ê' or 'Ê' or 'ë' or 'Ë' => "e",
            'í' or 'Í' or 'ì' or 'Ì' or 'î' or 'Î' or 'ï' or 'Ï' => "i",
            'ó' or 'Ó' or 'ò' or 'Ò' or 'ô' or 'Ô' or 'õ' or 'Õ' => "o",
            'ú' or 'Ú' or 'ù' or 'Ù' or 'û' or 'Û' => "u",

            // Consonants
            'ç' or 'Ç' => "c",
            'ñ' or 'Ñ' => "n",
            'ý' or 'Ý' or 'ỳ' or 'Ỳ' or 'ŷ' or 'Ŷ' or 'ÿ' => "y",

            // Default: return the lowercase character
            _ when char.IsLetter(c) => char.ToLowerInvariant(c).ToString(),
            _ => "-"
        };
    }
}
