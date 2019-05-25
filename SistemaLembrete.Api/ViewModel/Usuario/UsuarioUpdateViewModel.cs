
using SistemaLembrete.Domain.Entities;

namespace SistemaLembrete.Api.ViewModel.Usuario
{
    public class UsuarioUpdateViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }

        public static implicit operator UsuarioEntity(UsuarioUpdateViewModel viewModel)
        {
            UsuarioEntity usuario = new UsuarioEntity(viewModel.Id, viewModel.Nome, viewModel.Email);

            return usuario;
        }
    }
}
