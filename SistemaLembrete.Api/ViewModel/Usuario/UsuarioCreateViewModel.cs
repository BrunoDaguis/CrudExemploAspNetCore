
using SistemaLembrete.Domain.Entities;

namespace SistemaLembrete.Api.ViewModel.Usuario
{
    public class UsuarioCreateViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

        public static implicit operator UsuarioEntity(UsuarioCreateViewModel viewModel)
        {
            UsuarioEntity usuario = new UsuarioEntity(viewModel.Nome, viewModel.Cpf, viewModel.Email);
            
            return usuario;
        }
    }
}
