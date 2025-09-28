using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.ProfessionalCat;
using eCommerceApp.Application.Services.Interfaces;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Interfaces;


namespace eCommerceApp.Application.Services.Implementations
{
    public class ProfessionalCategoryService(IGeneric<ProfessionalCategory> profCategoryInterface, IMapper mapper) : IProfessionalCategoryService
    {
        public async Task<ServiceResponse> AddAsync(CreateProfessionalCategory category)
        {
            var mappedData = mapper.Map<ProfessionalCategory>(category);
            int result = await profCategoryInterface.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category created!") : new ServiceResponse(false, "Category failed to be deleted!"); ;
        }
        public async Task<ServiceResponse> DeleteAsync(Guid id)
        {
            int result = await profCategoryInterface.DeleteAsync(id);
            return result > 0 ? new ServiceResponse(true, "Category deleted!") : new ServiceResponse(false, "Category not found or failed to be deleted!");
        }
        public async Task<IEnumerable<GetProfessionalCategory>> GetAllAsync()
        {
            var rawData = await profCategoryInterface.GetAllAsync();
            return !rawData.Any() ? [] : mapper.Map<IEnumerable<GetProfessionalCategory>>(rawData);
        }

        public async Task<GetProfessionalCategory> GetByIdAsync(Guid id)
        {
            var rawData = await profCategoryInterface.GetByIdAsync(id);
            return rawData == null ? new GetProfessionalCategory() : mapper.Map<GetProfessionalCategory>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProfessionalCategory category)
        {
            var mappedData = mapper.Map<ProfessionalCategory>(category);
            int result = await profCategoryInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Category updated!") : new ServiceResponse(false, "Category failed to be update!");
        }
    }
}
