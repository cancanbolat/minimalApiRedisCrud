using MinApiRedis.DTO;
using System.Threading.Tasks;

namespace MinApiRedis.Services
{
    public interface IFavoriteService
    {
        Task<FavoriteDto> GetFavorites(string userId);
        Task<bool> Save(AddFavoriteDto favoriteDto);
        Task<bool> Delete(string userId);
    }
}
