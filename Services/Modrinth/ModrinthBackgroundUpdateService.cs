using Microsoft.EntityFrameworkCore;
using Modrinth;
using ModStats.API.Database;
using ModStats.API.Util;

namespace ModStats.API.Services.Modrinth;

public class ModrinthBackgroundUpdateService : DelayedService<ModrinthBackgroundUpdateService>
{
    private static readonly TimeSpan Delay = TimeSpan.FromHours(6);
    private static readonly TimeSpan StartupDelay = TimeSpan.FromSeconds(10);
    
    public ModrinthBackgroundUpdateService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory) : base(serviceProvider, loggerFactory, Delay, StartupDelay) { }
    
    protected override async Task Run(IServiceScope scope, object? state, CancellationToken cancellationToken)
    {
        using (Logger.BeginScope("Modrinth Update"))
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var modrinthPlatform = await dbContext.Platforms.Where(it => it.Slug == "modrinth").FirstOrDefaultAsync(cancellationToken) ?? throw new Exception("Modrinth platform not found");
            var platformKeys = dbContext.ModsSupportedPlatforms.Where(it => it.Platform == modrinthPlatform).Include(modSupportedPlatform => modSupportedPlatform.Mod).ToList();

            Logger.LogInformation("Fetching data for {Count} modrinth mods", platformKeys.Count);
            
            var modrinthClient = scope.ServiceProvider.GetRequiredService<ModrinthClient>();
            await ModrinthUpdateService.UpdateModrinthData(dbContext, modrinthClient, modrinthPlatform, platformKeys, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);
            
            Logger.LogInformation("Successfully updated modrinth stats");
        }
    }
}