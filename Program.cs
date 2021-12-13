using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using MinApiRedis.Configurations;
using MinApiRedis.DTO;
using MinApiRedis.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.MyConfigureServices();

var app = builder.Build();

app.UseCors();
app.UseHealthChecks("/healthcheck", new HealthCheckOptions
{
    Predicate = registration => true
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

//Endpoints
app.MapGet("/{userId}", (IFavoriteService favoriteService, string userId) =>
    favoriteService.GetFavorites(userId)
);

app.MapPost("/add", (IFavoriteService favoriteService, AddFavoriteDto addFavoriteDto) =>
    favoriteService.Save(addFavoriteDto)
);

app.MapSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API v1"));
app.Run();