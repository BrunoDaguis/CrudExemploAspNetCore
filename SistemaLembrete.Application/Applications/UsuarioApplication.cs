
using SistemaLembrete.Application.Applications.Base;
using SistemaLembrete.Application.Interfaces;
using SistemaLembrete.Core.Notifications;
using SistemaLembrete.Domain.Entities;
using SistemaLembrete.Domain.Interfaces;

namespace SistemaLembrete.Application.Applications
{
    public class UsuarioApplication : BaseApplication<UsuarioEntity>, IUsuarioApplication
    {
        public UsuarioApplication(IUsuarioRepository usuarioRepository, NotificationContext notificationContext)
            : base(usuarioRepository, notificationContext)
        {

        }
    }
}
