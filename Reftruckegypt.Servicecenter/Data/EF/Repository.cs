using System;
using Reftruckegypt.Servicecenter.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Reftruckegypt.Servicecenter.Data.Abstractions;
using System.Linq.Expressions;

namespace Reftruckegypt.Servicecenter.Data.EF
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : EntityBase
    {
        protected DbContext _context;
        public Repository(DbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);
        }

        public TEntity Find(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public IEnumerable<TEntity> Find()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsEnumerable();
        }
        public IEnumerable<TEntity> Find(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return orderBy(_context.Set<TEntity>()).AsEnumerable();
        }
        public bool Exists(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Count(predicate) > 0;
        }
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy)
        {
            return orderBy(_context.Set<TEntity>().Where(predicate)).AsEnumerable();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public void Remove(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
    }
}
