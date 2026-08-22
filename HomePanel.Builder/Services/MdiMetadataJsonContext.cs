using System.Text.Json.Serialization;
using HomePanel.Builder.Models;

namespace HomePanel.Builder.Services;

[JsonSourceGenerationOptions(
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase)]
[JsonSerializable(typeof(MdiIcon))]
[JsonSerializable(typeof(MdiIcon[]))]
internal partial class MdiMetadataJsonContext : JsonSerializerContext
{
}
