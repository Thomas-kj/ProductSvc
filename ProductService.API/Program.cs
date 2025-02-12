using Microsoft.EntityFrameworkCore;
using ProductService.API.Data;
using ProductService.API.Repositories;
using ProductService.API.Repositories.Interfaces;
using ProductService.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

#region Registering database connectivity
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));
#endregion

// Add services to the container.
builder.Services.AddScoped<IProductService, ProductService.API.Services.ProductService>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
