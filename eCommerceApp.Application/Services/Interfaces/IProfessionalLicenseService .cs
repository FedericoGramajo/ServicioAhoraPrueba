using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.ProfessionalLicense;
using eCommerceApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Services.Interfaces
{
    public interface IProfessionalLicenseService
    {
        Task<IEnumerable<GetProfessionalLicense>> GetAllAsync();
        Task<GetProfessionalLicense> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateProfessionalLicense license);
        Task<ServiceResponse> UpdateAsync(UpdateProfessionalLicense license);
        Task<ServiceResponse> DeleteAsync(Guid id);
    }
}
