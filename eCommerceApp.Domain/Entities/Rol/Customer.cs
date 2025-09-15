using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerceApp.Domain.Entities.ServicioAhora;
using eCommerceApp.Domain.Entities.Identity;

namespace eCommerceApp.Domain.Entities.Rol
{
    public class Customer
    {
        [Key, ForeignKey(nameof(AppUser))]
        public string? Id { get; set; } = default!;

        public AppUser AppUser { get; set; } = default!;
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<RatingService> Ratings { get; set; } = new List<RatingService>();
    }

}