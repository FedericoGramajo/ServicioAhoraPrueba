using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Domain.Entities.ServicioAhora
{
    public class ServiceStatus
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string? Name { get; set; }

        public ICollection<Service> Services { get; set; } = new List<Service>();
    }

}