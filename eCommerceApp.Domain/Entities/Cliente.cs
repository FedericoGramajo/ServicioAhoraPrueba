using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using eCommerceApp.Domain.Entities.Identity;

namespace eCommerceApp.Domain.Entities
{
    public class Cliente
    {
        [Key, ForeignKey(nameof(AppUser))]
        public int Id { get; set; }
        public AppUser AppUser { get; set; } = null!;
    }
}

