using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Domain.Entities
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(200)]
        public string? Street { get; set; }

        [Required, MaxLength(100)]
        public string? City { get; set; }

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        public ICollection<AppUserAddress> AppUserAddresses { get; set; } = new List<AppUserAddress>();
    }

}
