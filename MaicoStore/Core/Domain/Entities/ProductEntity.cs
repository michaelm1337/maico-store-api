using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class ProductEntity : BaseEntity
    {
        [Required, MinLength(1), MaxLength(40)]
        public string? Name { get; set; }
        [Required, MaxLength(400)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string? ImageUrl { get; set; }
    }
}
