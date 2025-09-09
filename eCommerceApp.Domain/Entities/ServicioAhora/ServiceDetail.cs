using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain.Entities.ServicioAhora
{
    public class ServiceDetail
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ServiceId { get; set; }

        [Required]
        public Guid ServiceOfferingId { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; } = default!;

        [ForeignKey(nameof(ServiceOfferingId))]
        public ServiceOffering ServiceOffering { get; set; } = default!;
    }

}