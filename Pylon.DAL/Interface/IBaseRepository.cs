using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Pylon.DAL.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "");

        TEntity GetById<TKey>(TKey id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete<TKey>(TKey id);
        void Delete(TEntity entity);
        void SaveChanges();
    }
}
