using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.DTOs.ProfessionalCat
{
    public class BaseProfessionalCategory
    {
        public string ProfessionalId { get; set; } = default!;
        public Guid CategoryId { get; set; }

    }
}
