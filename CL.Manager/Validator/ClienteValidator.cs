using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CL.Core.Domains;
using FluentValidation;

namespace CL.Manager.Validator
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.").MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("A data de nascimento é obrigatório.").LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Sexo).NotEmpty().WithMessage("O genêro é obrigatório.").Length(1).Must(IsMorF).WithMessage("Sexo precisa ser M ou F");
            RuleFor(x => x.Telefone).NotEmpty().WithMessage("O telefone é obrigatório.").Matches("[2-9][0-9]{10}").WithMessage("O telefone tem que ter o formato [2-9][0-9]{10}");
            RuleFor(x => x.Documento).NotEmpty().WithMessage("O documento é obrigatório.").MinimumLength(4).MaximumLength(14);
        }

        private bool IsMorF(string Sexo)
        {
            return Sexo == "M" || Sexo == "F";
        }

    }
}