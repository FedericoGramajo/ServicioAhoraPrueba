using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Domain.Entities
{
    public class CategoryOld
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
