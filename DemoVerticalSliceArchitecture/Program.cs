using DemoVerticalSliceArchitecture.Exceptions;
using DemoVerticalSliceArchitecture.Features.Category;
using DemoVerticalSliceArchitecture.Features.Product;
using DemoVerticalSliceArchitecture.Infrastructure;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>
    (option => option.UseSqlite(builder.Configuration.GetConnectionString("Connection")));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
TypeAdapterConfig.GlobalSettings.Scan(typeof(GetProductMappingConfig).Assembly);
var app = builder.Build();

app.UseExceptionHandler(_ => {  }); 
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.MapScalarApiReference();
app.MapControllers();
app.MapProductEndpoints();
app.MapCategoryEndpoints();
app.Run();
