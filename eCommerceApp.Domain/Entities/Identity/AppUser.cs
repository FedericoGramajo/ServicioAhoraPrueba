using eCommerceApp.Domain.Entities.Rol;
using Microsoft.AspNetCore.Identity;

namespace eCommerceApp.Domain.Entities.Identity
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Customer? Customer { get; set; }
        public Professional? Professional { get; set; }
        public ICollection<AppUserAddress> AppUserAddresses { get; set; } = new List<AppUserAddress>();
    }
}
