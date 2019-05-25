
using SistemaLembrete.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SistemaLembrete.Api.ViewModel.Usuario
{
    public class UsuarioGetViewModel
    {
        public UsuarioGetViewModel(int id, string nome, string cpf, string email)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
        }

        public UsuarioGetViewModel()
        {

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public static UsuarioGetViewModel Parse(UsuarioEntity usuarioEntity)
            => new UsuarioGetViewModel(usuarioEntity.Id, usuarioEntity.Nome, usuarioEntity.Cpf, usuarioEntity.Email);

        public static IEnumerable<UsuarioGetViewModel> Parse(IEnumerable<UsuarioEntity> usuarioEntities)
            => usuarioEntities.Select(x=> UsuarioGetViewModel.Parse(x));
    }
}
