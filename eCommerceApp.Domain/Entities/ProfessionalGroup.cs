using eCommerceApp.Domain.Entities.Rol;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain.Entities
{
    public class ProfessionalGroup
    {
        [Required]
        public Guid GroupId { get; set; }

        [Required]
        public string? ProfessionalId { get; set; }

        [ForeignKey(nameof(GroupId))]
        public Group Group { get; set; } = default!;

        [ForeignKey(nameof(ProfessionalId))]
        public Professional Professional { get; set; } = default!;
    }

}