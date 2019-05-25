using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation.Results;
using SistemaLembrete.Application.Interfaces.Base;
using SistemaLembrete.Core.Notifications;
using SistemaLembrete.Domain.Interfaces.Base;

namespace SistemaLembrete.Application.Applications.Base
{
    public class BaseApplication<TEntity> : IBaseApplication<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly NotificationContext _notificationContext;
        public BaseApplication(IBaseRepository<TEntity> repository, NotificationContext notificationContext)
        {
            _repository = repository;
            _notificationContext = notificationContext;
        }

        public async Task Add(TEntity entity)
        {
            var Invalid = (bool)entity.GetType().GetProperty("Invalid").GetValue(entity, null);

            if (Invalid)
            {
                var validationResult = (ValidationResult)entity.GetType().GetProperty("ValidationResult").GetValue(entity, null);

                _notificationContext.Add(validationResult);

                return;
            }


            await _repository.Add(entity);
        }

        public async Task Delete(TEntity entity)
        {
            await _repository.Delete(entity);
        }

        public async Task<IEnumerable<TEntity>> Get()
        {
            return await _repository.Get();
        }

        public async Task<TEntity> Get(int id)
        {
            return await _repository.Get(id);
        }

        public async Task Update(TEntity entity)
        {
            await _repository.Update(entity);
        }
    }
}
