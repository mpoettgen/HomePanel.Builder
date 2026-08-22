namespace HomePanel.Builder.Client.Services;

public interface IIconService
{
    Task<string> GetIconMarkup(string iconId);
    string[] GetIconNames(string searchTerm);
}