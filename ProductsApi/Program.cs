using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Interfaces;
using ProductsApi.Models;
using ProductsApi.Repositories;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySQL(connectionString));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();



using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/api/products", async (IProductRepository repository) =>
{
    var products = await repository.GetAllProductsAsync();
    return Results.Ok(products);
});

app.MapGet("/api/products/{id}", async (int id, IProductRepository repository) =>
{
    var product = await repository.GetProductByIdAsync(id);
    return product is not null ? Results.Ok(product) : Results.NotFound();
});


app.MapGet("/api/health", () => Results.Ok("Service Running!"));

app.MapPost("/api/products", async ([FromBody] Product newProduct, IProductRepository repository) =>
{
    var createdProduct = await repository.CreateProductAsync(newProduct);
    return Results.Created($"/api/products/{createdProduct.Id}", createdProduct);
});

app.MapPut("/api/products/{id}", async (int id, [FromBody] Product updatedProduct, IProductRepository repository) =>
{
    var result = await repository.UpdateProductAsync(id, updatedProduct);
    return result ? Results.NoContent() : Results.NotFound();
});

app.MapDelete("/api/products/{id}", async (int id, IProductRepository repository) =>
{
    var result = await repository.DeleteProductAsync(id);
    return result ? Results.NoContent() : Results.NotFound();
});

app.Run();