using CL.CoreShared.ModelViews;
using FluentValidation;

namespace CL.Manager.Validator
{
    public class NovoClienteValidator : AbstractValidator<NovoCliente>
    {
        public NovoClienteValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.").MinimumLength(3).WithMessage("O nome deve ter no mínimo 3 caracteres");
            RuleFor(x => x.DataNascimento).NotEmpty().WithMessage("A data de nascimento é obrigatório.").LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130));
            RuleFor(x => x.Sexo).NotEmpty().WithMessage("O genêro é obrigatório.").Length(1).Must(IsMorF).WithMessage("Sexo precisa ser M ou F");
            RuleFor(x => x.Telefones).NotEmpty().WithMessage("O telefone é obrigatório.");
            RuleFor(x => x.Documento).NotEmpty().WithMessage("O documento é obrigatório.").MinimumLength(4).MaximumLength(14);
            RuleFor(x => x.Endereco).SetValidator(new NovoEnderecoValidator());
        }

        private bool IsMorF(string Sexo)
        {
            return Sexo == "M" || Sexo == "F";
        }

    }
}