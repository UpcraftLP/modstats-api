namespace ModStats.API.Services;

public interface IDataInitService
{
    Task InitData(CancellationToken cancellationToken = default);
}

public class DataInitService : IDataInitService
{
    private readonly IMcVersionService _mcVersionService;
    
    public DataInitService(IMcVersionService mcVersionService)
    {
        _mcVersionService = mcVersionService;
    }

    public async Task InitData(CancellationToken cancellationToken = default)
    {
        await _mcVersionService.UpdateVersionsFromPistonMeta(cancellationToken);
    }
}