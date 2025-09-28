using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.DTOs.ProfessionalLicense
{
    public class UpdateProfessionalLicense : BaseProfessionalLicense
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
    }
}
