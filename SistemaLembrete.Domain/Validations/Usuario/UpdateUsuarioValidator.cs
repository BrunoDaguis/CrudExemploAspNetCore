using FluentValidation;
using SistemaLembrete.Domain.Entities;

namespace SistemaLembrete.Domain.Validations.Usuario
{
    public class UpdateUsuarioValidator : AbstractValidator<UsuarioEntity>
    {
        public UpdateUsuarioValidator()
        {
            RuleFor(a => a.Id)
                .NotEqual(0)
                .WithMessage("Identificação do usuário não informada");

            RuleFor(a => a.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email Inválido");

            RuleFor(a => a.Nome)
                .NotEmpty()
                .WithMessage("Nome não informado");
        }
    }
}
