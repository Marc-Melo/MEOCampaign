using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Interfaces.Repositories;
using MEOCampaign.Core.Interfaces.Services;

namespace MEOCampaign.Core.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity entity)
        {
            if(entity == null)
                throw new ArgumentNullException(nameof(entity));

            _repository.Add(entity);
        }    

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => _repository.Find(predicate);

        public TEntity Get(int id)
            => _repository.Get(id);

        public IEnumerable<TEntity> GetAll()
            => _repository.GetAll();

        public void Remove(TEntity entity)
            => _repository.Remove(entity);

        public void Dispose()
            => _repository.Dispose();
    }
}
