using HomePanel.Builder.Client.Models;

namespace HomePanel.Builder.Client.Services;

/// <summary>
/// Provides operations for creating, loading, saving, and generating configurations
/// for panel designs.
/// </summary>
public interface IPanelDesignsProvider
{
    /// <summary>
    /// Gets information about all available panel designs.
    /// </summary>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// an array of available panel design information.
    /// </returns>
    Task<DesignInfo[]> GetDesignInfos();

    /// <summary>
    /// Adds a new panel design using the specified panel information.
    /// </summary>
    /// <param name="newPanelInfo">
    /// The information required to create the new panel design.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// information about the newly created panel design.
    /// </returns>
    Task<DesignInfo> AddNewPanel(NewPanelInfo newPanelInfo);

    /// <summary>
    /// Loads a panel design by name.
    /// </summary>
    /// <param name="name">
    /// The name of the panel design to load.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains
    /// the requested panel design.
    /// </returns>
    Task<PanelDesign> LoadPanelDesign(string name);

    /// <summary>
    /// Saves a panel design using the specified name.
    /// </summary>
    /// <param name="name">
    /// The name under which to save the panel design.
    /// </param>
    /// <param name="panelDesign">
    /// The panel design to save.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous save operation.
    /// </returns>
    Task SavePanelDesign(string name, PanelDesign panelDesign);
}
