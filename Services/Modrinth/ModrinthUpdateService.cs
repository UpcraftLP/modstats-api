using Microsoft.EntityFrameworkCore;
using Modrinth;
using ModStats.API.Database;
using ModStats.API.Models.Histograms;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Services.Modrinth;

public interface IModrinthUpdateService
{
    Task UpdateDownloadCounts(Guid modId, CancellationToken cancellationToken = default);
}

public class ModrinthUpdateService : IModrinthUpdateService
{
    private readonly AppDbContext _dbContext;
    private readonly ModrinthClient _modrinthClient;
    
    public ModrinthUpdateService(AppDbContext dbContext, ModrinthClient modrinthClient)
    {
        _dbContext = dbContext;
        _modrinthClient = modrinthClient;
    }

    public async Task UpdateDownloadCounts(Guid modId, CancellationToken cancellationToken = default)
    {
        var mrPlatform = await _dbContext.Platforms.Where(it => it.Slug == "modrinth").FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Modrinth platform not found");
        var mod = await _dbContext.Mods.Where(it => it.Id == modId).Include(it => it.SupportedVersions).ThenInclude(it => it.Id).Include(it => it.PlatformIDs).ThenInclude(supportedPlatform => supportedPlatform.Platform).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Mod not found with Id " + modId);
        var toUpdate = mod.PlatformIDs.Where(it => it.Platform == mrPlatform).ToList();

        await UpdateModrinthData(_dbContext, _modrinthClient, mrPlatform, toUpdate, cancellationToken);
    }
    
    public static async Task UpdateModrinthData(AppDbContext dbContext, ModrinthClient modrinthClient, Platform modrinthPlatform, IReadOnlyCollection<ModSupportedPlatform> toUpdate, CancellationToken cancellationToken = default)
    {
        var response = await modrinthClient.Project.GetMultipleAsync(toUpdate.Select(it => it.PlatformKey));

        foreach (var data in response)
        {
            var platformData = toUpdate.FirstOrDefault(it => it.PlatformKey == data.Id);
            if (platformData == null) continue;
            
            platformData.DownloadCount = data.Downloads;
            dbContext.Update(platformData);

            var downloadCountSnapshot = new DownloadCountSnapshot
            {
                Data = data.Downloads,
                Mod = platformData.Mod,
                Platform = modrinthPlatform,
            };
            await dbContext.AddAsync(downloadCountSnapshot, cancellationToken);

            foreach (var versionName in data.GameVersions)
            {
                var version = await dbContext.MinecraftVersions.Where(it => it.Id == versionName).FirstOrDefaultAsync(cancellationToken);
                if (version == null || platformData.Mod.SupportedVersions.Contains(version))
                {
                    continue;
                }
                platformData.Mod.SupportedVersions.Add(version);
            }
            dbContext.Update(platformData.Mod);

            var supportedVersionsSnapshot = new SupportedVersionsSnapshot
            {
                Data = platformData.Mod.SupportedVersions.ToList(),
                Mod = platformData.Mod,
                Platform = modrinthPlatform,
            };
            await dbContext.AddAsync(supportedVersionsSnapshot, cancellationToken);
        }
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}