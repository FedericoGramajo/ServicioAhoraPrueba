using AutoMapper;
using eCommerceApp.Application.DTOs.Cart;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.Identity;
using eCommerceApp.Application.DTOs.Identity.Rol.Professional;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Application.DTOs.ServicioAhora.ServOffering;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Entities.Identity;
using eCommerceApp.Domain.Entities.Rol;
using eCommerceApp.Domain.Entities.ServicioAhora;

namespace eCommerceApp.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<CreateCategory, CategoryOld>();
            CreateMap<CreateProduct, Product>();

            CreateMap<CategoryOld, GetCategory>();
            CreateMap<Product, GetProduct>();

           // CreateMap<CreateUser, AppUser>();
            CreateMap<LoginUser, AppUser>();

            CreateMap<PaymentMethod, GetPaymentMethod>();
            CreateMap<CreateAchieve, Achieve>();

            CreateMap<CreateUser, AppUser>()
            .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<Professional, GetProfessional>()
           .ForMember(d => d.AppUserId, opt => opt.MapFrom(s => s.Id))
           .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.AppUser.FullName))
           .ForMember(d => d.Email, opt => opt.MapFrom(s => s.AppUser.Email))
           .ForMember(d => d.Licenses, opt => opt.MapFrom(s => s.Licenses.Select(l => l.Number)))
           .ForMember(d => d.Categories, opt => opt.MapFrom(s => s.ProfessionalCategories.Select(pc => pc.Category.Name)))
           .ForMember(d => d.ServicesCount, opt => opt.MapFrom(s => s.Services.Count))
           .ForMember(d => d.AvgRating, opt => opt.MapFrom(s => s.Ratings.Any() ? s.Ratings.Average(r => r.Score) : 0));


            CreateMap<ServiceOffering, GetServiceOffering>()
          .ForMember(d => d.ProfessionalFullName,
                     o => o.MapFrom(s => s.Professional.AppUser.FullName))
          .ForMember(d => d.CategoryName,
                    o => o.MapFrom(s => s.Category.Name)); 

            // Create -> Entity
            CreateMap<CreateServiceOffering, ServiceOffering>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.UpdatedAt, o => o.Ignore())
                .ForMember(d => d.Professional, o => o.Ignore()) // la FK alcanza
                .ForMember(d => d.Category, o => o.Ignore())
                .ForMember(d => d.ServiceDetails, o => o.Ignore());

            // Update -> Entity
            CreateMap<UpdateServiceOffering, ServiceOffering>()
                // Si NO querés permitir cambiar el owner, ignorá la FK:
                .ForMember(d => d.ProfessionalId, o => o.Ignore())
                .ForMember(d => d.CreatedAt, o => o.Ignore())
                .ForMember(d => d.UpdatedAt, o => o.Ignore())
                .ForMember(d => d.Professional, o => o.Ignore())
                .ForMember(d => d.Category, o => o.Ignore())
                .ForMember(d => d.ServiceDetails, o => o.Ignore());

        }
    }
}
