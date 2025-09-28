using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.DTOs.Category
{
    public class BaseProfessionalCategory
    {
        [Required]
        public string? Name { get; set; }

    }
}
