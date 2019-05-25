using SistemaLembrete.Domain.Entities;
using SistemaLembrete.Domain.Interfaces;
using SistemaLembrete.Repository.Context;
using SistemaLembrete.Repository.Repositories.Base;
using System.Threading.Tasks;

namespace SistemaLembrete.Repository.Repositories
{
    public class UsuarioRepository : BaseRepository<UsuarioEntity>, IUsuarioRepository
    {

        public UsuarioRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public new async Task Update(UsuarioEntity entity)
        {
            var user = new UsuarioEntity() { Id = entity.Id, Email = entity.Email, Nome = entity.Nome };

            DatabaseContext.Usuario.Attach(user);
            DatabaseContext.Entry(user).Property(x => x.Email).IsModified = true;
            DatabaseContext.Entry(user).Property(x => x.Nome).IsModified = true;

            await DatabaseContext.SaveChangesAsync();

        }
    }
}
