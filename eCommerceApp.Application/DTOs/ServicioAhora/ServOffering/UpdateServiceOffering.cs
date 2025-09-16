using System.ComponentModel.DataAnnotations;

namespace eCommerceApp.Application.DTOs.ServicioAhora.ServOffering
{
    public sealed class UpdateServiceOffering : BaseServiceOffering
        {
            [Required]
            public Guid Id { get; set; }
        }
    
}
