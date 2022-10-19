using API.DarkShame.Domain.Interfaces;
using API.DarkShame.Domain.Interfaces.Contrys;
using API.DarkShame.Services;
using API.DarkShame.Services.Contrys;
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
