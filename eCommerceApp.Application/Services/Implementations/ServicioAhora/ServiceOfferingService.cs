using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Identity.Rol.Professional;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.DTOs.ServicioAhora.ServOffering;
using eCommerceApp.Application.Services.Interfaces.ServcioAhora;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.ServicioAhora;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Domain.Interfaces.ServicioAhora;

namespace eCommerceApp.Application.Services.Implementations.ServicioAhora
{
    public class ServiceOfferingService(IGeneric<ServiceOffering> serviceOfferingInterface, IMapper mapper, IServiceOffering serviceOfferingSpecifics) : IServiceOfferingService
    {
        public async Task<ServiceResponse> AddAsync(CreateServiceOffering serviceOffering)
        {
            var mappedData = mapper.Map<ServiceOffering>(serviceOffering);
            int result = await serviceOfferingInterface.AddAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Service Offering created!") : new ServiceResponse(false, "Service Offering failed to be create!");
        }

        public async Task<IEnumerable<GetServiceOffering>> GetAllAsync()
        {
            var rawData = await serviceOfferingSpecifics.GetAllAsync();
            return !rawData.Any() ? [] : mapper.Map<IEnumerable<GetServiceOffering>>(rawData);
        }

        public async Task<GetServiceOffering> GetByIdAsync(Guid id)
        {
            var rawData = await serviceOfferingSpecifics.GetByIdAsync(id);
            return rawData == null ? new GetServiceOffering() : mapper.Map<GetServiceOffering>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateServiceOffering serviceOffering)
        {
            var mappedData = mapper.Map<ServiceOffering>(serviceOffering);
            int result = await serviceOfferingInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Service Offering updated!") : new ServiceResponse(false, "Service Offering failed to be update!");
        }

        //public async Task<ServiceResponse> DeleteAsync(Guid id)
        //{
        //    int result = await productInterface.DeleteAsync(id);
        //    return result > 0 ? new ServiceResponse(true, "Product deleted!") : new ServiceResponse(false, "Product not found or failed to be deleted!");
        //}

    }
}
