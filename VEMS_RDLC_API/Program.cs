using Scalar.AspNetCore; // Scalar UI namespace
using Microsoft.EntityFrameworkCore;
using VEMS.PrintEngine.Data;
using VEMS.PrintEngine.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DB. Get connection string from appsettings
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the DbContext to SQL Server
builder.Services.AddDbContext<VemsDbContext>(options =>
    options.UseSqlServer(connectionString));

// Register the printing service engine
builder.Services.AddScoped<IFeeVoucherService, FeeVoucherService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Ensure standard Swagger services are registered
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Configure Swagger to use a standard OpenAPI route template
    app.UseSwagger(options =>
    {
        options.RouteTemplate = "openapi/{documentName}.json";
    });

    // Map the Scalar UI endpoint
    app.MapScalarApiReference(); 
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
