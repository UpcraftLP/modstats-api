using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ModStats.API.Models.Minecraft;

[Table("mc_versions")]
public class McVersion
{
    [Key]
    [Required]
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("type")]
    public McVersionType Type { get; set; }
    
    [JsonPropertyName("url")]
    public Uri Url { get; set; }
    
    [JsonPropertyName("time")]
    public DateTime Time { get; set; }
    
    [JsonPropertyName("releaseTime")]
    public DateTime ReleaseTime { get; set; }
    
    [JsonPropertyName("sha1")]
    public string Sha1 { get; set; }
    
    [JsonPropertyName("complianceLevel")]
    public int ComplianceLevel { get; set; } = 0;
}

[JsonConverter(typeof(McVersionTypeConverter))]
public enum McVersionType
{
    OldAlpha,
    OldBeta,
    Release,
    Snapshot, 
}

public static class McVersionJsonConverter
{
    public static readonly JsonSerializerOptions SerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new McVersionTypeConverter(),
            new UtcDateTimeConverter(),
        },
    };
}

internal class UtcDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TryGetDateTime(out var dateTime))
        {
            return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
        }
        return default;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        if (value.Kind != DateTimeKind.Utc)
        {
            throw new ArgumentException("DateTime value must be in UTC.");
        }
        writer.WriteStringValue(value.ToUniversalTime());
    }
}


internal class McVersionTypeConverter : JsonConverter<McVersionType>
{
    public override McVersionType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value switch
        {
            "old_alpha" => McVersionType.OldAlpha,
            "old_beta" => McVersionType.OldBeta,
            "release" => McVersionType.Release,
            "snapshot" => McVersionType.Snapshot,
            var _ => throw new JsonException("unknown version type: " + value),
        };
    }

    public override void Write(Utf8JsonWriter writer, McVersionType value, JsonSerializerOptions options)
    {
        var str = value switch
        {
            McVersionType.OldAlpha => "old_alpha",
            McVersionType.OldBeta => "old_beta",
            McVersionType.Release => "release",
            McVersionType.Snapshot => "snapshot",
            var _ => throw new JsonException("unknown version type: " + value),
        };
        writer.WriteStringValue(str);
    }
}