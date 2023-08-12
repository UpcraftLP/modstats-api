using CurseForge.APIClient;
using CurseForge.APIClient.Models.Mods;
using Microsoft.EntityFrameworkCore;
using ModStats.API.Database;
using ModStats.API.Models.Histograms;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Services;

public interface ICurseforgeUpdateService
{
    Task UpdateDownloadCounts(Guid modId, CancellationToken cancellationToken = default);
}

public class CurseforgeUpdateService : ICurseforgeUpdateService
{
    private readonly AppDbContext _dbContext;
    private readonly ApiClient _cfApiClient;
    
    public CurseforgeUpdateService(AppDbContext dbContext, ApiClient cfApiClient)
    {
        _dbContext = dbContext;
        _cfApiClient = cfApiClient;
    }

    public async Task UpdateDownloadCounts(Guid modId, CancellationToken cancellationToken = default)
    {
        var cfPlatform = await _dbContext.Platforms.Where(it => it.Slug == "curseforge").FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Curseforge platform not found");
        var mod = await _dbContext.Mods.Where(it => it.Id == modId).Include(it => it.PlatformIDs).ThenInclude(supportedPlatform => supportedPlatform.Platform).FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Mod not found with Id " + modId);
        var toUpdate = mod.PlatformIDs.Where(it => it.Platform == cfPlatform).ToList();

        await UpdateCfData(_dbContext, _cfApiClient, cfPlatform, toUpdate, cancellationToken);

    }
    public static async Task UpdateCfData(AppDbContext dbContext, ApiClient cfApiClient, Platform curseforgePlatform, IReadOnlyCollection<ModSupportedPlatform> toUpdate, CancellationToken cancellationToken = default)
    {
        var response = await cfApiClient.GetModsByIdListAsync(new GetModsByIdsListRequestBody()
        {
            ModIds = toUpdate.Select(it => it.PlatformKey).Select(int.Parse).ToList(),
        });

        foreach (var data in response.Data)
        {
            //TODO error handling?
            if (data == null) continue;

            var platformData = toUpdate.FirstOrDefault(it => it.PlatformKey == data.Id.ToString());
            if (platformData == null) continue;

            var snapshot = new DownloadCountSnapshot
            {
                Data = data.DownloadCount,
                Mod = platformData.Mod,
                Platform = curseforgePlatform,
            };
            await dbContext.AddAsync(snapshot, cancellationToken);

            platformData.DownloadCount = data.DownloadCount;
            dbContext.Update(platformData);
        }
    }
}