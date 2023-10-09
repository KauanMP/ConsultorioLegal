using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.CoreShared.ModelViews;
using FluentValidation;

namespace CL.Manager.Validator
{
    public class AlteraClienteValidator : AbstractValidator<AlteraCliente>
    {
        public AlteraClienteValidator()
        {
            RuleFor(p => p.Id).NotEmpty().GreaterThan(0);
            Include(new NovoClienteValidator());
        }
    }
}