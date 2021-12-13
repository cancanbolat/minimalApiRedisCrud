namespace MinApiRedis.DTO
{
    public class AddFavoriteDto
    {
        public string UseId { get; set; }
        public string AdvertId { get; set; }
        public string AdvertTitle { get; set; }
        public decimal Price { get; set; }
    }
}
