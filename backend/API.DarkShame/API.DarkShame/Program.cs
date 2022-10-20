using API.DarkShame.Domain.Interfaces.Contrys;
using API.DarkShame.Domain.Interfaces.Groups;
using API.DarkShame.Domain.Interfaces.Server;
using API.DarkShame.Domain.Interfaces.Store.Game;
using API.DarkShame.Domain.Interfaces.Users;
using API.DarkShame.Services.Contrys;
using API.DarkShame.Services.Groups;
using API.DarkShame.Services.Server;
using API.DarkShame.Services.Store.Game;
using API.DarkShame.Services.Users;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

var cultureInfo = new CultureInfo("pt-BR");

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

builder.Services.AddControllers();

//Users
builder.Services.AddScoped<IServiceUser, ServiceUser>();

//Contry - State - City
builder.Services.AddScoped<IServiceContry, ServiceContry>();
builder.Services.AddScoped<IServiceState, ServiceState>();
builder.Services.AddScoped<IServiceCity, ServiceCity>();

//Groups
builder.Services.AddScoped<IServiceGroupInfo, ServiceGroupInfo>();

//Server
builder.Services.AddScoped<IServiceServerInfo, ServiceServerInfo>();

//Games
builder.Services.AddScoped<IServiceGames, ServiceGames>();
builder.Services.AddScoped<IServiceAnalysis, ServiceAnalysis>();
builder.Services.AddScoped<IServiceLanguage, ServiceLanguage>();
builder.Services.AddScoped<IServiceResources, ServiceResources>();
builder.Services.AddScoped<IServiceSpecifications, ServiceSpecifications>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(opt => opt.AddPolicy("CorsPolicy", c =>
{
    c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
