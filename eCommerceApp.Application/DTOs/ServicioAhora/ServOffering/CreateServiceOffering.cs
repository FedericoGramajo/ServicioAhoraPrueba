using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.DTOs.ServicioAhora.ServOffering
{
    public class CreateServiceOffering : BaseServiceOffering
        {
            [Required]
            public string ProfessionalId { get; set; } = default!;
        }
    
}
