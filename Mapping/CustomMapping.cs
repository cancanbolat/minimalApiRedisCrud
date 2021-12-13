using AutoMapper;
using MinApiRedis.DTO;

namespace MinApiRedis.Mapping
{
    public class CustomMapping : Profile
    {
        public CustomMapping()
        {
            CreateMap<FavoriteDto, AddFavoriteDto>().ReverseMap();
        }
    }
}
