using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using Microsoft.EntityFrameworkCore;
using ModStats.API.Database;
using ModStats.API.DataTransfer.Mods;
using ModStats.API.Models.Mods;
using ModStats.API.Services.Curseforge;
using ModStats.API.Services.Modrinth;
using ModStats.API.Util.Auth;

namespace ModStats.API.Controllers;

public class ModsController : GraphController
{
    private readonly AppDbContext _dbContext;
    private readonly ICurseforgeUpdateService _curseforge;
    private readonly IModrinthUpdateService _modrinth;

    public ModsController(AppDbContext dbContext, ICurseforgeUpdateService curseforge, IModrinthUpdateService modrinth)
    {
        _dbContext = dbContext;
        _curseforge = curseforge;
        _modrinth = modrinth;
    }

    [QueryRoot("mods")]
    public IQueryable<Mod> GetMods()
    {
        return _dbContext.Mods.AsQueryable();
    }

    [ApiKey]
    [MutationRoot("addMod")]
    public async Task<Mod> AddMod(AddModsInput mod, CancellationToken cancellationToken = default)
    {
        var platforms = mod.SupportedPlatforms.Select(it => new ModSupportedPlatform()
        {
            Platform = _dbContext.Platforms.FirstOrDefault(pl => pl.Slug == it.Platform) ?? throw new KeyNotFoundException("No such platform: " + it.Platform),
            PlatformKey = it.Id,
        }).ToList();

        var result = new Mod()
        {
            Id = mod.ModId.GetValueOrDefault(Guid.Empty),
            Slug = mod.Slug,
        };
        
        foreach (var platform in platforms)
        {
            result.PlatformIDs.Add(platform);
        }
        
        _dbContext.Mods.Add(result);
        _dbContext.ModsSupportedPlatforms.AddRange(platforms);
        await _dbContext.SaveChangesAsync(cancellationToken);

        await _modrinth.UpdateDownloadCounts(result.Id, cancellationToken);
        await _curseforge.UpdateDownloadCounts(result.Id, cancellationToken);

        return result;
    }

    [ApiKey]
    [MutationRoot("deleteMod")]
    public async Task<int> DeleteMod(Guid modid)
    {
        var count = 0;
        count += await _dbContext.HistDownloadCounts.Where(it => it.ModId == modid).ExecuteDeleteAsync();
        count += await _dbContext.ModsSupportedPlatforms.Where(it => it.ModId == modid).ExecuteDeleteAsync();
        count += await _dbContext.ModsMetaData.Where(it => it.ModId == modid).ExecuteDeleteAsync();
        count += await _dbContext.Mods.Where(it => it.Id == modid).ExecuteDeleteAsync();
        count += await _dbContext.SaveChangesAsync();
        return count;
    }
}