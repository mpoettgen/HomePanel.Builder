using System.Reflection;
using System.Text.Json;
using HomePanel.Builder.Models;

namespace HomePanel.Builder.Services;

public class MdiIconProvider(IWebHostEnvironment webHostEnvironment) : IIconProvider
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;
    MdiIcon[]? _icons = default;

    public const string IconSource = "mdi";
    public string Source { get; } = IconSource;

    private void EnsureMetadataLoaded()
    {
        if (_icons != null)
            return;

        Assembly assembly = typeof(MdiIconProvider).Assembly;
        string resourceName = $"{nameof(HomePanel)}.{nameof(Builder)}.iconroot.icons.mdi.meta.json";
        using Stream resource = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Resource not found: {resourceName}");
        _icons = JsonSerializer.Deserialize(resource, MdiMetadataJsonContext.Default.MdiIconArray)
            ?? throw new InvalidOperationException("Failed to deserialize icon data");
    }

    public string[] GetIconNames(string searchTerm)
    {
        EnsureMetadataLoaded();
        string[] terms = searchTerm.ToLowerInvariant().Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        if (!terms.Any(t => t != string.Empty))
            return [.. _icons!.Select(icon => icon.Name)];
        return [.. _icons!.Where(i => Matches(i, terms)).Select(icon => icon.Name)];
    }

    private static bool Matches(MdiIcon icon, string[] terms)
    {
        foreach (string term in terms)
        {
            if (!icon.Name.Contains(term, StringComparison.OrdinalIgnoreCase)
                && !icon.Aliases.Any(l => l.Contains(term, StringComparison.OrdinalIgnoreCase)))
                return false;
        }

        return true;
    }

    public async Task<string> GetIconMarkup(string name)
    {
        string iconPath = Path.Combine(_webHostEnvironment.ContentRootPath, "iconroot", "icons", "mdi", "svg", $"{name}.svg");
        return await File.ReadAllTextAsync(iconPath);
    }
}
