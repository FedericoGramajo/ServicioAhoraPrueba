using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.ProfessionalCat;
using eCommerceApp.Application.DTOs.ProfessionalLicense;
using eCommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Services.Interfaces
{
    public interface IProfessionalCategoryService
    {
        Task<IEnumerable<GetProfessionalCategory>> GetAllAsync();
        Task<GetProfessionalCategory> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateProfessionalCategory category);
        Task<ServiceResponse> UpdateAsync(UpdateProfessionalCategory category);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
