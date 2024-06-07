using System.ComponentModel.DataAnnotations;

namespace stroymarket_net_api.Dtos;

public record ProductDto(
  int Id,
  string NameUz,
  string NameRu,
  decimal Price,
  DateTime CreatedAt,
  string ImageUri
);


public record CreateProductDto(
  [Required]
  [StringLength(50)]
  string NameUz,
  [Required]
  [StringLength(50)]
  string NameRu,
  decimal Price,
  DateTime CreatedAt,
  [Url]
  string ImageUri
);

public record UpdateProductDto(
  [Required]
  [StringLength(50)]
  string NameUz,
  [Required]
  [StringLength(50)]
  string NameRu,
  decimal Price,
  DateTime CreatedAt,
  [Url]
  string ImageUri
);