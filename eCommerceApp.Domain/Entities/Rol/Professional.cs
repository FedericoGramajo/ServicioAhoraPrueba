using eCommerceApp.Domain.Entities.ServicioAhora;
using eCommerceApp.Domain.Entities.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain.Entities.Rol
{
    public class Professional
    {
        [Key, ForeignKey(nameof(AppUser))]
        public string Id { get; set; } = default!;

        public AppUser AppUser { get; set; } = default!;
        public ICollection<ProfessionalLicense> Licenses { get; set; } = new List<ProfessionalLicense>();
        public ICollection<ProfessionalGroup> ProfessionalGroups { get; set; } = new List<ProfessionalGroup>();
        public ICollection<ProfessionalCategory> ProfessionalCategories { get; set; } = new List<ProfessionalCategory>();
        public ICollection<ServiceOffering> ServiceOfferings { get; set; } = new List<ServiceOffering>();
        public ICollection<Service> Services { get; set; } = new List<Service>();
        public ICollection<RatingService> Ratings { get; set; } = new List<RatingService>();
    }

}

