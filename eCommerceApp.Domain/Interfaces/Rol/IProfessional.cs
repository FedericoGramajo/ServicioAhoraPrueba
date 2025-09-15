using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Domain.Interfaces.Rol
{
    public interface IProfessional
    {
        Task<IEnumerable<Professional>> GetAllAsync();
        Task<Professional> GetByIdAsync(string id);
    }
}
