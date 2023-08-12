using CurseForge.APIClient;
using Microsoft.EntityFrameworkCore;
using ModStats.API.Database;
using ModStats.API.Util;

namespace ModStats.API.Services.Curseforge;

public class CurseforgeBackgroundUpdateService : DelayedService<CurseforgeBackgroundUpdateService>
{
    private static readonly TimeSpan Delay = TimeSpan.FromHours(6);
    private static readonly TimeSpan StartupDelay = TimeSpan.FromSeconds(10);

    public CurseforgeBackgroundUpdateService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory) : base(serviceProvider, loggerFactory, Delay, StartupDelay)
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
            await CurseforgeUpdateService.UpdateCurseforgeData(dbContext, cf, cfPlatform, platformKeys, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            Logger.LogInformation("Successfully updated curseforge stats");
        }
    }
}