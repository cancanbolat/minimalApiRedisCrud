using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MinApiRedis.Services;

namespace MinApiRedis.Configurations
{
    public static class ConfigureServiceExtension
    {
        public static IServiceCollection MyConfigureServices(this IServiceCollection services)
        {
            //Health Checks
            services.AddHealthChecks().AddRedis("localhost:6379");

            //Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Minimal API", Version = "v1" });
            });

            //Redis Service DI
            services.AddSingleton<RedisService>(redis =>
            {
                var redisService = new RedisService();
                redisService.Connect();

                return redisService;
            });

            //CORS
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });

            //Favorites Service DI
            services.AddScoped<IFavoriteService, FavoriteService>();

            return services;
        }
    }
}
