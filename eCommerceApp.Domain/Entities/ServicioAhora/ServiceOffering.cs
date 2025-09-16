using eCommerceApp.Domain.Entities.Rol;
using eCommerceApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Domain.Entities.ServicioAhora
{
    public class ServiceOffering : IAuditable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? ProfessionalId { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal BasePrice { get; set; }

        public int? EstimatedDuration { get; set; } 

        
        public bool Status { get; set; } = true;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey(nameof(ProfessionalId))]
        public Professional Professional { get; set; } = default!;

        public ICollection<ServiceDetail> ServiceDetails { get; set; } = new List<ServiceDetail>();
    }

}
