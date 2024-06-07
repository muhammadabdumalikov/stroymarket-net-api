using System.ComponentModel.DataAnnotations;

namespace stroymarket_net_api.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public required string NameUz { get; set; }
        [Required]
        [StringLength(50)]
        public required string NameRu { get; set; }
        public required decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        [Url]
        public required string ImageUri { get; set; }
    }
}