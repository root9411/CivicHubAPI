using CivicHubKiosk.Repositories;
using Microsoft.EntityFrameworkCore;
using SharedLibrary;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Application.Interface;
using SharedLibrary.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CivicHubDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlOptions =>
        {
            sqlOptions.MigrationsAssembly("SharedLibrary.Infrastructure");
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            );
        }
    )
);


builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(
        typeof(CreateKioskCommand).Assembly));

builder.Services.AddScoped<IKioskRepository, KioskRepository>();
builder.Services.AddScoped<IKioskReadRepository, KioskRepository>();
builder.Services.AddScoped<IEncryptionService, EncryptionService>();
builder.Services.AddScoped<IPageRepository, PageRepository>();
builder.Services.AddScoped<IElectricityRepository, ElectricityRepository>();
builder.Services.AddScoped<IWaterReppository, WaterRepository > ();
builder.Services.AddScoped<IGasRepository, GasRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<RestrictAccessMiddleware>();
app.MapControllers();

app.Run();
