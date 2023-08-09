using CurseForge.APIClient;
using GraphQL.AspNet.Configuration;
using Microsoft.EntityFrameworkCore;
using ModStats.API.Database;
using ModStats.API.Services;
using ModStats.API.Util.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddHttpClient();
builder.Services.AddGraphQL();
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));
builder.Services.AddTransient<ApiClient>(_ =>
{
    var config = builder.Configuration.GetSection(CurseForgeConfig.SectionName).Get<CurseForgeConfig>()!;
    return new ApiClient(config.ApiKey, config.PartnerId, config.ContactEmail);
});
builder.Services.AddScoped<IMcVersionService, McVersionService>();
builder.Services.AddTransient<IDataInitService, DataInitService>();
builder.Services.AddHostedService<FetchMcMetaService>();

var app = builder.Build();
app.UseGraphQL();

Init(app).Wait();
app.Run();
return;

async Task Init(IHost host)
{
    using var scope = host.Services.CreateScope();
    
    // run pending database migrations
    await scope.ServiceProvider.GetRequiredService<AppDbContext>().Database.MigrateAsync();
    
    // fetch version manifest and update database
    await scope.ServiceProvider.GetRequiredService<IDataInitService>().InitData();
}