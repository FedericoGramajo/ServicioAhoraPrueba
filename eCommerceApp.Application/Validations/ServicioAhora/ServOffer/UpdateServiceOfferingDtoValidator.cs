using eCommerceApp.Application.DTOs.ServicioAhora.ServOffering;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceApp.Application.Validations.ServicioAhora
{
    public class UpdateServiceOfferingValidator : AbstractValidator<UpdateServiceOffering>
    {
        public UpdateServiceOfferingValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(150);
            RuleFor(x => x.Description).MaximumLength(500);
            RuleFor(x => x.BasePrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.EstimatedDuration).GreaterThan(0).When(x => x.EstimatedDuration.HasValue);
        }
    }
}
