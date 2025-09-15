using AutoMapper;
using eCommerceApp.Application.DTOs.Cart;
using eCommerceApp.Application.DTOs.Category;
using eCommerceApp.Application.DTOs.Identity;
using eCommerceApp.Application.DTOs.Identity.Rol.Professional;
using eCommerceApp.Application.DTOs.Product;
using eCommerceApp.Domain.Entities;
using eCommerceApp.Domain.Entities.Cart;
using eCommerceApp.Domain.Entities.Identity;
using eCommerceApp.Domain.Entities.Rol;

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

        }
    }
}
