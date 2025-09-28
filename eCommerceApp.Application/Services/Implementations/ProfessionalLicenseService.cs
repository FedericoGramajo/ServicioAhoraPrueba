using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.DTOs.ProfessionalLicense;
using eCommerceApp.Application.DTOs.ServicioAhora.ServOffering;
using eCommerceApp.Application.Services.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Domain.Interfaces.CategorySpecifics;

namespace eCommerceApp.Application.Services.Implementations
{
    public class ProfessionalLicenseService(IGeneric<ProfessionalLicense> licenseInterface, IMapper mapper) : IProfessionalLicenseService
    {
        public async Task<ServiceResponse> AddAsync(CreateProfessionalLicense license)
        {
            var mappedData = mapper.Map<ProfessionalLicense>(license);
            int result = await licenseInterface.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category created!") : new ServiceResponse(false, "Category failed to be deleted!"); ;
        }

        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await licenseInterface.DeleteAsync(id);
            return result > 0 ? new ServiceResponse(true, "License deleted!") : new ServiceResponse(false, "License not found or failed to be deleted!");
        }
        public async Task<IEnumerable<GetProfessionalLicense>> GetAllAsync()
        {
            var rawData = await licenseInterface.GetAllAsync();
            return !rawData.Any() ? [] : mapper.Map<IEnumerable<GetProfessionalLicense>>(rawData);
        }

        public async Task<GetProfessionalLicense> GetByIdAsync(Guid id)
        {
            var rawData = await licenseInterface.GetByIdAsync(id);
            return rawData == null ? new GetProfessionalLicense() : mapper.Map<GetProfessionalLicense>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProfessionalLicense license)
        {
            var mappedData = mapper.Map<ProfessionalLicense>(license);
            int result = await licenseInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "License updated!") : new ServiceResponse(false, "License failed to be update!");
        }

    }
}
