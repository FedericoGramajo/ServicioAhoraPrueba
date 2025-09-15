using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.DTOs.Identity
{
    public enum UserType { Customer, Professional }
    public class CreateUser: BaseModel
    {
        public required string FullName { get; set; }
        public required string ConfirmPassword { get; set; }
        public required UserType UserType { get; set; }
    }
}
