
using Microsoft.EntityFrameworkCore;
using SistemaLembrete.Domain.Interfaces.Base;
using SistemaLembrete.Repository.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaLembrete.Repository.Repositories.Base
{   
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected DatabaseContext DatabaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            DatabaseContext = databaseContext;
        }

        public async Task Add(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Add(entity);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            DatabaseContext.Set<TEntity>().Remove(entity);
            await DatabaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await DatabaseContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            return await DatabaseContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity entity)
        {
            DatabaseContext.Entry(entity).State = EntityState.Modified;
            await DatabaseContext.SaveChangesAsync();
        }
    }
}
