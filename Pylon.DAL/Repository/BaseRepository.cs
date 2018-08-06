using Pylon.DAL.Context;
using Pylon.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Pylon.DAL.UserManager
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly PylonContext _pylonContext;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(PylonContext context)
        {
            _pylonContext = context;
            _dbSet = _pylonContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            return GetFilteredQuery(filter, orderBy, includeProperties).ToList();
        }

        public TEntity GetById<TKey>(TKey id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Attach(entity);
            _pylonContext.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _pylonContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<TKey>(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (_pylonContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }

            _dbSet.Remove(entity);
        }

        public void SaveChanges()
        {
             _pylonContext.SaveChanges();
        }

        private IQueryable<TEntity> GetFilteredQuery(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var includes = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }
    }
}
