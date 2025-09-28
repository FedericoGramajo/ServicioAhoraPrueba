using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.ServicioAhora;

namespace eCommerceApp.Application.DTOs.Category
{
    public class GetCategory : BaseProfessionalCategory
    {
        public Guid Id { get; set; }

        //public ICollection<ProfessionalCategory>? ProfessionalCategories { get; set; }
        public ICollection<ServiceOffering>? ServiceOfferingsCategories { get; set; }
    }
}
