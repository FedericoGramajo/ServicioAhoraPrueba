using eCommerceApp.Domain.Entities.Rol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain.Entities
{
    public class ProfessionalCategory
    {
        [Required]
        public string? ProfessionalId { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [ForeignKey(nameof(ProfessionalId))]
        public Professional Professional { get; set; } = default!;

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = default!;
    }

}