using Microsoft.EntityFrameworkCore;
using ProductApp.Data;
using ProductApp.Services;
using ProductApp.Data;
using ProductApp.Services;
using ProductApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddDbContext<ProductContext>(options =>
//    options.UseInMemoryDatabase("ProductsDB"));
builder.Services.AddDbContext<ProductContext>();
builder.Services.AddDbContext<BookContext>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(s =>
{
    //s.EnableAnnotations();
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
