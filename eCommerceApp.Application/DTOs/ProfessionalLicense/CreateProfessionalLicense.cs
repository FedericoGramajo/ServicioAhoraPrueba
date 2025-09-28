using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.DTOs.ProfessionalLicense
{
    public class CreateProfessionalLicense : BaseProfessionalLicense
    {
        public Guid Id { get; set; }
        public string ProfessionalId { get; set; } = default!;
    }
}
