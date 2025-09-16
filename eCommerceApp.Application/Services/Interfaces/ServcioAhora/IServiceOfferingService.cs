using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.ServicioAhora.ServOffering;

namespace eCommerceApp.Application.Services.Interfaces.ServcioAhora
{
    public interface IServiceOfferingService
    {
        Task<IEnumerable<GetServiceOffering>> GetAllAsync();
        Task<GetServiceOffering> GetByIdAsync(Guid id);
        Task<ServiceResponse> AddAsync(CreateServiceOffering serviceOffering);
        Task<ServiceResponse> UpdateAsync(UpdateServiceOffering serviceOffering);
        //Task<ServiceResponse> DeleteAsync(Guid id);
        //esta va a ser una baja logica?
    }
}
