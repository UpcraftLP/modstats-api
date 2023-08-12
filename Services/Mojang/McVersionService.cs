using ModStats.API.Database;
using ModStats.API.Util.Minecraft;

namespace ModStats.API.Services.Mojang;

public interface IMcVersionService
{
    Task UpdateVersionsFromPistonMeta(CancellationToken cancellationToken = default);
}

public class McVersionService : IMcVersionService
{
    private readonly AppDbContext _dbContext;
    private readonly HttpClient _httpClient;
    private readonly ILogger _logger;

    public McVersionService(AppDbContext dbContext, IHttpClientFactory httpClientFactory, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
        _httpClient = httpClientFactory.CreateClient();
        _logger = loggerFactory.CreateLogger("McVersionService");
    }

    public async Task UpdateVersionsFromPistonMeta(CancellationToken cancellationToken = default)
    {
        using (_logger.BeginScope("UpdateVersionsFromPistonMeta"))
        {
            _logger.LogInformation("Fetching latest MC version manifest");
            var manifest = await FetchVersionManifest(cancellationToken);
            var previousVersions = _dbContext.MinecraftVersions.Select(v => v.Id).ToHashSet();
            foreach (var mcVersion in manifest.Versions)
            {
                if (!previousVersions.Contains(mcVersion.Id))
                {
                    await _dbContext.MinecraftVersions.AddAsync(mcVersion, cancellationToken);
                }
            }
            var result = await _dbContext.SaveChangesAsync(cancellationToken);

            _logger.LogInformation("Updated MC version cache, {Count} changes", result);
        }
    }

    private async Task<VersionManifestV2> FetchVersionManifest(CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.GetAsync("https://piston-meta.mojang.com/mc/game/version_manifest_v2.json", cancellationToken);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to fetch version manifest");
        }

        var json = await VersionManifestV2.FromJsonAsync(await response.Content.ReadAsStreamAsync(cancellationToken), cancellationToken);
        return json ?? throw new Exception("unable to deserialize version manifest");
    }
}