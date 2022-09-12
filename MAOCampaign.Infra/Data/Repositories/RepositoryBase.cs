using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MEOCampaign.Core.Interfaces.Repositories;
using MEOCampaign.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace MEOCampaign.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class, new()
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Where(predicate);

        public TEntity Get(int id)        
            => _context.Set<TEntity>().Find(id);
        
        public IEnumerable<TEntity> GetAll()
            => _context.Set<TEntity>().ToList();

        public void Dispose()
            => _context.Dispose();
    }
}
