using System.Text.Json.Serialization;
using HomePanel.Builder.Client.Models;
using HomePanel.Builder.Models;
using SharpYaml.Serialization;

namespace HomePanel.Builder.Services;

[YamlSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate)]
[YamlSerializable(typeof(PanelDesignBase))]
[YamlSerializable(typeof(PanelDesign))]
[YamlSerializable(typeof(PanelInfo))]
internal partial class DesignFileYamlContext : YamlSerializerContext
{
}
