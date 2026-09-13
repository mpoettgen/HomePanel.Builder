namespace HomePanel.Builder.Client.Services;

/// <summary>
/// Provides operations for creating, loading, saving, and generating configurations
/// for panel designs.
/// </summary>
public interface IConfigurationGenerator
{
    /// <summary>
    /// Generates a configuration for the panel design with the specified name.
    /// </summary>
    /// <param name="name">
    /// The name of the panel design for which to generate the configuration.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous configuration-generation operation.
    /// </returns>
    Task Generate(string name);
}
