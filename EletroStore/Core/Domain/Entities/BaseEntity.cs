using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;

        [Required]
        public DateTimeOffset Modified { get; set; } = DateTimeOffset.Now;
    }
}
