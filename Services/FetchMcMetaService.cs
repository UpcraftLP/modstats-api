using ModStats.API.Util;

namespace ModStats.API.Services;

public class FetchMcMetaService : DelayedService<FetchMcMetaService>
{
    private static readonly TimeSpan Delay = TimeSpan.FromHours(1);
    
    public FetchMcMetaService(IServiceProvider serviceProvider, ILoggerFactory loggerFactory) : base(serviceProvider, loggerFactory, Delay, Delay) { }
    
    protected override async Task Run(IServiceScope scope, object? state, CancellationToken cancellationToken)
    {
        var mcVersionService = scope.ServiceProvider.GetRequiredService<IMcVersionService>();
        await mcVersionService.UpdateVersionsFromPistonMeta(cancellationToken);
    }
}