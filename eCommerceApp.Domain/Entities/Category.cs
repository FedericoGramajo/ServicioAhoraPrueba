using eCommerceApp.Domain.Entities.ServicioAhora;
using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public ICollection<ProfessionalCategory> ProfessionalCategories { get; set; } = new List<ProfessionalCategory>();
        public ICollection<ServiceOffering> ServiceOfferingsCategories { get; set; } = new List<ServiceOffering>();
    }

}