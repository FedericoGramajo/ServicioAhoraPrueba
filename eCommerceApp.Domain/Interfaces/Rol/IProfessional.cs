using eCommerceApp.Domain.Entities.Rol;

namespace eCommerceApp.Domain.Interfaces.Rol
{
    public interface IProfessional
    {
        Task<IEnumerable<Professional>> GetAllAsync();
        Task<Professional> GetByIdAsync(string id);
    }
}
