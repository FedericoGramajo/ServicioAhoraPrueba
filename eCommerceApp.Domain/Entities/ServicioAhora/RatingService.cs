using eCommerceApp.Domain.Entities.Rol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain.Entities.ServicioAhora
{
    public class RatingService
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? CustomerId { get; set; }

        [Required]
        public string? ProfessionalId { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [Range(1, 5)]
        public int Score { get; set; }

        [MaxLength(500)]
        public string? Comment { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = default!;

        [ForeignKey(nameof(ProfessionalId))]
        public Professional Professional { get; set; } = default!;

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = default!;
    }

}