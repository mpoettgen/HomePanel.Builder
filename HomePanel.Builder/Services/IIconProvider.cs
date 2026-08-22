namespace HomePanel.Builder.Services;

public interface IIconProvider
{
    string Source { get; }

    Task<string> GetIconMarkup(string name);
    string[] GetIconNames(string searchTerm);
}
