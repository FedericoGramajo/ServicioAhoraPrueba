using AutoMapper;
using eCommerceApp.Application.DTOs;
using eCommerceApp.Application.DTOs.Identity.Rol.Professional;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.Services.Interfaces.Rol;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Rol;
using eCommerceApp.Domain.Interfaces;
using eCommerceApp.Domain.Interfaces.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Services.Implementations.Rol
{
    public class ProfessionalService(IGeneric<Professional> professionalInterface, IMapper mapper, IProfessional professionalSpecifics) : IProfessionalService
    {
        public async Task<IEnumerable<GetProfessional>> GetAllAsync()
        {
            var rawData = await professionalSpecifics.GetAllAsync();
            return !rawData.Any() ? [] : mapper.Map<IEnumerable<GetProfessional>>(rawData);
        }

        public async Task<GetProfessional> GetByIdAsync(string id)
        {
            var rawData = await professionalSpecifics.GetByIdAsync(id);
            return rawData == null ? new GetProfessional() : mapper.Map<GetProfessional>(rawData);
        }

        public async Task<ServiceResponse> UpdateAsync(UpdateProfessional professional)
        {
            var mappedData = mapper.Map<Professional>(professional);
            int result = await professionalInterface.UpdateAsync(mappedData);
            return result > 0 ? new ServiceResponse(true, "Professional updated!") : new ServiceResponse(false, "Professional failed to be update!");
        }
    }
}
