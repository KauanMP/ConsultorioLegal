using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CL.CoreShared.ModelViews;
using FluentValidation;

namespace CL.Manager.Validator
{
    public class NovoEnderecoValidator : AbstractValidator<NovoEndereco>
    {
        public NovoEnderecoValidator()
        {
            RuleFor(p => p.Cidade).NotEmpty().MaximumLength(200);
        }
    }
}