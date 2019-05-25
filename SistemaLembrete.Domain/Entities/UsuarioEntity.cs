
using SistemaLembrete.Domain.Entities.Base;
using SistemaLembrete.Domain.Validations.Usuario;
using System;

namespace SistemaLembrete.Domain.Entities
{
    public class UsuarioEntity : EntidadeBase
    {
        public UsuarioEntity()
        {
            DataCadastro = DateTime.Now;
        }

        public UsuarioEntity(string nome, string cpf, string email)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            DataCadastro = DateTime.Now;

            Validate(this, new CreateUsuarioValidator());
        }

        public UsuarioEntity(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;

            Validate(this, new UpdateUsuarioValidator());
        }

        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
