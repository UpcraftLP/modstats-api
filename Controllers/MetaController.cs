using GraphQL.AspNet.Attributes;
using GraphQL.AspNet.Controllers;
using ModStats.API.Database;
using ModStats.API.Models.Minecraft;
using ModStats.API.Models.Mods;
using ModStats.API.Models.Mods.Loaders;
using ModStats.API.Models.Platforms;

namespace ModStats.API.Controllers;

public class MetaController : GraphController
{
    private readonly AppDbContext _dbContext;
    
    public MetaController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [QueryRoot("platforms")]
    public IQueryable<Platform> GetPlatforms()
    {
        return _dbContext.Platforms.AsQueryable();
    }
    
    [QueryRoot("loaders")]
    public IQueryable<ModLoader> GetLoaders()
    {
        return _dbContext.ModLoaders.AsQueryable();
    }
    
    [QueryRoot("versions")]
    public IQueryable<McVersion> GetVersions()
    {
        return _dbContext.MinecraftVersions.AsQueryable();
    }
}