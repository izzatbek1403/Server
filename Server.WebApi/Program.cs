using Server.Application.DependencyInjection;
using Server.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Service registrations
builder.Services.AddControllers(); // Controller support ekler
builder.Services.AddEndpointsApiExplorer(); // API Explorer ekler

// Swagger/OpenAPI configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = builder.Configuration["ApiSettings:Title"] ?? "GBS Management API", // API başlığı
        Version = builder.Configuration["ApiSettings:Version"] ?? "v1", // API versiyonu
        Description = builder.Configuration["ApiSettings:Description"] ?? "ERP ve E-Ticaret API", // API açıklaması
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = builder.Configuration["ApiSettings:ContactName"] ?? "Admin", // İletişim adı
            Email = builder.Configuration["ApiSettings:ContactEmail"] // İletişim email
        }
    });
});

// CORS configuration - frontend bağlantısı için
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Tüm origin'lere izin ver (dev için)
              .AllowAnyMethod() // Tüm HTTP method'larına izin
              .AllowAnyHeader(); // Tüm header'lara izin
    });
});

// Custom service registrations
builder.Services.AddApplication(); // Application katmanı servisleri
builder.Services.AddInfrastructure(builder.Configuration); // Infrastructure katmanı servisleri

var app = builder.Build();

// Development environment configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Swagger JSON endpoint'i aktif et
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "GBS Management API v1"); // Swagger UI endpoint
        c.RoutePrefix = string.Empty; // Ana sayfa olarak Swagger'ı göster
    });
}

// Middleware pipeline
app.UseHttpsRedirection(); // HTTPS yönlendirmesi
app.UseCors("AllowAll"); // CORS policy uygula
app.UseAuthorization(); // Authorization middleware

app.MapControllers(); // Controller route'larını map et

// Application startup
try
{
    app.Run(); // Uygulamayı başlat
}
catch (Exception ex)
{
    Console.WriteLine($"Uygulama başlatılamadı: {ex.Message}"); // Startup hata logu
    throw;
}