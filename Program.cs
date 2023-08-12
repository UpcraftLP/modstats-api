using System.Reflection;
using CurseForge.APIClient;
using GraphQL.AspNet.Configuration;
using Microsoft.EntityFrameworkCore;
using Modrinth;
using ModStats.API.Database;
using ModStats.API.Services;
using ModStats.API.Services.Curseforge;
using ModStats.API.Services.Mojang;
using ModStats.API.Util.Auth;
using ModStats.API.Util.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging();
builder.Services.AddHttpClient();
builder.Services.AddGraphQL(options =>
{
    options.ExecutionOptions.MaxQueryDepth = 20;
});
builder.Services.AddAuthorization();
builder.Services.AddSingleton<ApiKeyAuthorizationFilter>();
builder.Services.AddSingleton<IApiKeyValidator, ApiKeyValidator>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    var connString = builder.Configuration.GetConnectionString("Postgres") ?? throw new Exception("No connection string found!");
    if (builder.Environment.IsDevelopment() && !connString.Contains("Include Error Detail"))
    {
        if (!connString.EndsWith(';'))
        {
            connString += ';';
        }
        connString += "Include Error Detail=true;";
    }
    var contextBuilder = options.UseNpgsql(connString);
    if (builder.Environment.IsDevelopment())
    {
        contextBuilder.EnableSensitiveDataLogging();
    }
});
builder.Services.AddTransient<ApiClient>(_ =>
{
    var config = builder.Configuration.GetSection(CurseForgeConfig.SectionName).Get<CurseForgeConfig>()!;
    return new ApiClient(config.ApiKey, config.PartnerId, config.ContactEmail);
});
builder.Services.AddTransient<ModrinthClient>(a =>
{
    var config = builder.Configuration.GetSection(ModrinthConfig.SectionName).Get<ModrinthConfig>()!;
    var assemblyInfo = Assembly.GetEntryAssembly()!.GetName();
    var userAgentString = $"{assemblyInfo.FullName}/{assemblyInfo.Version} ({config.ContactEmail})";
    return new ModrinthClient(new ModrinthClientConfig()
    {
        ModrinthToken = config.ApiKey,
        UserAgent = userAgentString,
    });
});
builder.Services.AddScoped<IMcVersionService, McVersionService>();
builder.Services.AddScoped<ICurseforgeUpdateService, CurseforgeUpdateService>();
builder.Services.AddTransient<IDataInitService, DataInitService>();
builder.Services.AddHostedService<FetchMcMetaService>();
builder.Services.AddHostedService<CurseforgeBackgroundUpdateService>();

var app = builder.Build();
app.UseAuthorization();
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