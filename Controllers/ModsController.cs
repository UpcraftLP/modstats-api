using GraphQL.AspNet.Attributes;
using ModStats.API.Database;
using ModStats.API.Models.Mods;

namespace ModStats.API.Controllers;

public class ModsController
{
    private readonly AppDbContext _dbContext;
    
    public ModsController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [QueryRoot("mods")]
    public IQueryable<Mod> GetMods()
    {
        return _dbContext.Mods.AsQueryable();
    }
}