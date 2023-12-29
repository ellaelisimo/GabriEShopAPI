using FluentAssertions.Common;
using GabriEShopAPI.Clients;
using GabriEShopAPI.Context;
using GabriEShopAPI.Interfaces;
using GabriEShopAPI.Middleware;
using GabriEShopAPI.Repositories;
using GabriEShopAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "User ID=postgres;Password=Kicunilapa1991;Host=localhost;Port=5432;Database=ItemStore;";
//var connectionString = builder.Configuration["MySecrets:PostgreConnection"] ?? throw new ArgumentNullException("Connection string was not found."); 
//var connectionString = builder ?? throw new ArgumentNullException("Connection string was not found.");


// Add services to the container.
builder.Services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(connectionString));
builder.Services.AddDbContext<DataContext>(o => o.UseNpgsql(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IItemRepository, ItemRepositoryEF>();
//builder.Services.AddTransient<IItemRepository, ItemRepositoryDapper>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<IShoppingCartRepository, ShoppingCartRepositoryDapper>();
builder.Services.AddTransient<IShoppingCartService, ShoppingCartService>();
builder.Services.AddTransient<IShopService, ShopService>();
builder.Services.AddTransient<IShopRepository, ShopRepositoryDapper>();
builder.Services.AddTransient<IJsonPlaceholderClient, JsonPlaceholderClient>();

builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "GabriEShop", Version = "v1" });

    // Include the XML comments file
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
