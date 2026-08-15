using System.Text.Json.Serialization;
using HomePanel.Builder.Client.Models;
using SharpYaml.Serialization;

namespace HomePanel.Builder.Services;

[YamlSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.SnakeCaseLower,
    PreferredObjectCreationHandling = JsonObjectCreationHandling.Populate)]
[YamlSerializable(typeof(DeviceList))]
[YamlSerializable(typeof(DeviceInfo))]
internal partial class DeviceListYamlContext : YamlSerializerContext
{
}
