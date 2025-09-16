using eCommerceApp.Domain.Entities.ServicioAhora;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Domain.Interfaces.ServicioAhora
{
    public interface IServiceOffering
    {
        Task<IEnumerable<ServiceOffering>> GetAllAsync();
        Task<ServiceOffering> GetByIdAsync(Guid id);
        Task<int> DeleteAsync(Guid id);
    }
}
