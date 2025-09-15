using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Identity.Rol.Professional;
using eCommerceApp.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Services.Interfaces.Rol
{
    public interface IProfessionalService
    {
        Task<IEnumerable<GetProfessional>> GetAllAsync();
        Task<GetProfessional> GetByIdAsync(string id);
        Task<ServiceResponse> UpdateAsync(UpdateProfessional professional);
        //Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
