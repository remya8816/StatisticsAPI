using Ajman.Statistics.Api.Middleware;
using Ajman.Statistics.Application.Interfaces;
using Ajman.Statistics.Infrastructure.Auth;
using Ajman.Statistics.Infrastructure.Caching;
using Ajman.Statistics.Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add MemoryCache and caching service
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<ICacheService, MemoryCacheService>();

// Register application services
builder.Services.AddScoped<IHotelStatsService, HotelStatisticsService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// Register JwtTokenService
builder.Services.AddSingleton<IJwtTokenService>(provider =>
{
    var configuration = provider.GetRequiredService<IConfiguration>();
    var jwtKey = configuration["Jwt:Key"] ?? throw new Exception("JWT Key missing");
    return new JwtTokenService(jwtKey);
});

// Add controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Ajman Statistics API",
        Version = "v1"
    });
    // JWT Authentication
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token.\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6...\""
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ajman Statistics API v1");
    });
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
