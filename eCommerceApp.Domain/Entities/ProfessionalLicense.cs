using eCommerceApp.Domain.Entities.Rol;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Domain.Entities
{
    public class ProfessionalLicense
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? ProfessionalId { get; set; }
        [Required]
        public Guid CategoryId { get; set; }

        [Required, MaxLength(100)]
        public string Number { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Issuer { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime? ExpirationDate { get; set; }

        [ForeignKey(nameof(ProfessionalId))]
        public Professional Professional { get; set; } = default!;
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = default!;
    }
}
