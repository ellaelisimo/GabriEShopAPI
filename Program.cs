using GabriEShopAPI.Interfaces;
using GabriEShopAPI.Repositories;
using GabriEShopAPI.Services;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["MySecrets:PostgreConnection"] ?? throw new ArgumentNullException("Connection string was not found."); ;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IItemRepository, ItemRepository>();
builder.Services.AddTransient<IItemService, ItemService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
