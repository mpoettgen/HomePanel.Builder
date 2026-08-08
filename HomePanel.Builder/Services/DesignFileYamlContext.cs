using System.Text.Json.Serialization;
using HomePanel.Builder.Models;
using SharpYaml.Serialization;

namespace HomePanel.Builder.Services;

[YamlSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate)]
[YamlSerializable(typeof(DesignFileBaseInfo))]
[YamlSerializable(typeof(HomePanelInfo))]
internal partial class DesignFileYamlContext : YamlSerializerContext
{
}
