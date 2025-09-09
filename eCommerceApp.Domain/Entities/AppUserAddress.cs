using eCommerceApp.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceApp.Domain.Entities
{
    public class AppUserAddress
    {
        [Required]
        public Guid AddressId { get; set; }

        [Required]
        public string? AppUserId { get; set; }

        [MaxLength(50)]
        public string? Type { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser AppUser { get; set; } = default!;

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; } = default!;
    }

}