
using FluentValidation;
using SistemaLembrete.Domain.Entities;

namespace SistemaLembrete.Domain.Validations.Usuario
{
    public class CreateUsuarioValidator : AbstractValidator<UsuarioEntity>
    {
        public CreateUsuarioValidator()
        {
            RuleFor(a => a.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email Inválido");

            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("Nome não informado");

            RuleFor(a => a.Cpf)
                .NotEmpty()
                .WithMessage("CPF não informado");
        }
    }
}
