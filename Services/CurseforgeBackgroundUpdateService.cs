using CurseForge.APIClient;
using CurseForge.APIClient.Models.Mods;
using Microsoft.EntityFrameworkCore;
using ModStats.API.Database;
using ModStats.API.Models.Histograms;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Platforms;
using ModStats.API.Util;

namespace ModStats.API.Services;

public class CurseforgeBackgroundUpdateService : DelayedService<CurseforgeBackgroundUpdateService>
{
    private static readonly TimeSpan Delay = TimeSpan.FromHours(24);

    public CurseforgeBackgroundUpdateService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory) : base(serviceProvider, loggerFactory, Delay)
    {
    }

    protected override async Task Run(IServiceScope scope, object? state, CancellationToken cancellationToken)
    {
        using (Logger.BeginScope("Curseforge Update"))
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var cfPlatform = await dbContext.Platforms.Where(it => it.Slug == "curseforge").FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Curseforge platform not found");
            var platformKeys = dbContext.ModsSupportedPlatforms.Where(it => it.Platform == cfPlatform).Include(modSupportedPlatform => modSupportedPlatform.Mod).ToList();

            Logger.LogInformation("Fetching data for {Count} curseforge mods", platformKeys.Count);
            
            var cf = scope.ServiceProvider.GetRequiredService<ApiClient>();
            await CurseforgeUpdateService.UpdateCfData(dbContext, cf, cfPlatform, platformKeys, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            Logger.LogInformation("Successfully updated curseforge stats");
        }
    }
}