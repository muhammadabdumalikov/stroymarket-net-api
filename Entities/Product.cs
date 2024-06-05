namespace stroymarket_net_api.Entities
{
    public class Product
    {
        public required int Id { get; set; }
        public required string NameUz { get; set; }
        public required string NameRu { get; set; }
        public required decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public required string ImageUri { get; set; }
    }
}