using MinApiRedis.DTO;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace MinApiRedis.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly RedisService _redisService;

        public FavoriteService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<bool> Delete(string userId)
        {
            var dbstatus = await _redisService.GetDatabase().KeyDeleteAsync(userId);
            return dbstatus ? true : false;
        }

        public async Task<FavoriteDto> GetFavorites(string userId)
        {
            var favorites = await _redisService.GetDatabase().StringGetAsync(userId);

            if (string.IsNullOrEmpty(favorites))
            {
                return new FavoriteDto() { UserId = "?", FavoriteItem = null };

            }
            return JsonSerializer.Deserialize<FavoriteDto>(favorites);
        }

        public async Task<bool> Save(AddFavoriteDto favoriteDto)
        {
            var dbstatus = await _redisService.GetDatabase().StringSetAsync(favoriteDto.UseId, 
                JsonSerializer.Serialize(favoriteDto));

            return dbstatus ? true : false;
        }
    }
}
