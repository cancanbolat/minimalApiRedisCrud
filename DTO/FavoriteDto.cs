using System.Collections.Generic;

namespace MinApiRedis.DTO
{
    public class FavoriteDto
    {
        public string UserId { get; set; }
        public List<FavoriteItemDto> FavoriteItem { get; set; }
    }
}
