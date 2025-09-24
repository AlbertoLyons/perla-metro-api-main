using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using DotNetEnv;
using perla_metro_api_main.src.Handlers;

Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();

builder.Services.AddTransient<OcelotConfigure>();

var ocelotBuilder = builder.Services.AddOcelot(builder.Configuration);
ocelotBuilder.AddDelegatingHandler<OcelotConfigure>(true);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);


var app = builder.Build();

await app.UseOcelot();

app.Run();
