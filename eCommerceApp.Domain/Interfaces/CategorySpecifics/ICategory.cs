using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.ServicioAhora;

namespace eCommerceApp.Domain.Interfaces.CategorySpecifics
{
    public interface ICategory
    {
        Task<IEnumerable<Product>> GetProductsByCategory(Guid categoryId);
        Task<IEnumerable<ServiceOffering>> GetServOfferingByCategory(Guid categoryId);
        //Task<IEnumerable<ProfessionalCategory>> GetProfessionalByCategory(Guid categoryId);
    }
}
