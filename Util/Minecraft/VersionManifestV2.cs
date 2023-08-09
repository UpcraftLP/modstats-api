using System.Text.Json;
using System.Text.Json.Serialization;
using ModStats.API.Models.Minecraft;

namespace ModStats.API.Util.Minecraft;

// https://piston-meta.mojang.com/mc/game/version_manifest_v2.json
public class VersionManifestV2
{
    [JsonPropertyName("latest")]
    public Latest Latest { get; set; }
    [JsonPropertyName("versions")]
    public IEnumerable<McVersion> Versions { get; set; }
    
    public static VersionManifestV2? FromJson(string json) => JsonSerializer.Deserialize<VersionManifestV2>(json, McVersionJsonConverter.SerializerOptions);
    public static async Task<VersionManifestV2?> FromJsonAsync(Stream stream, CancellationToken cancellationToken)
    {
        return await JsonSerializer.DeserializeAsync<VersionManifestV2>(stream, McVersionJsonConverter.SerializerOptions, cancellationToken);
    }
}

public class Latest
{
    [JsonPropertyName("release")]
    public string Release { get; set; }
    
    [JsonPropertyName("snapshot")]
    public string Snapshot { get; set; }
}
