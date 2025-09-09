using eCommerceApp.Domain.Entities.Rol;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Domain.Entities.ServicioAhora
{
    public class Service
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string? CustomerId { get; set; }

        [Required]
        public string? ProfessionalId { get; set; }

        [Required]
        public Guid StatusId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = default!;

        [ForeignKey(nameof(ProfessionalId))]
        public Professional Professional { get; set; } = default!;

        [ForeignKey(nameof(StatusId))]
        public ServiceStatus Status { get; set; } = default!;

        public ICollection<ServiceDetail> Details { get; set; } = new List<ServiceDetail>();
        public ICollection<RatingService> Ratings { get; set; } = new List<RatingService>();
    }

}
