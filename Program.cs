using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using perla_metro_api_main.src.Handlers;

// Load environment variables from .env file
Env.Load();
// Create a builder for the web application
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services
    // Add Authentication with JWT Bearer
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
        ValidateIssuer = true,
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER") ?? throw new ArgumentNullException("Issuer cannot be null or empty."),
        ValidateAudience = true,
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE") ?? throw new ArgumentNullException("Audience cannot be null or empty."),
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SIGNING_KEY") ?? throw new ArgumentNullException("Signing key cannot be null or empty."))),
        };
    }
);

// Configure Ocelot with settings from ocelot.json and environment variables
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true).AddEnvironmentVariables();
// Register custom delegating handler for loading API KEY from environment variable
builder.Services.AddTransient<OcelotConfigure>();
// Add Ocelot services
var ocelotBuilder = builder.Services.AddOcelot(builder.Configuration);
// Register the custom delegating handler with Ocelot
ocelotBuilder.AddDelegatingHandler<OcelotConfigure>(true);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);


var app = builder.Build();

await app.UseOcelot();

app.Run();
