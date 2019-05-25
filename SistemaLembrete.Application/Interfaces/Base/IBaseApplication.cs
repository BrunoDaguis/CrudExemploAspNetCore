using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaLembrete.Application.Interfaces.Base
{
    public interface IBaseApplication<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> Get(int id);
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
