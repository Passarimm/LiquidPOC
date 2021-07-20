using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LiquidPoc.Domain.Interfaces.Repositories
{
    public interface _IBaseRepository<TEntity, TId>
     where TEntity : class
     where TId : struct
    {
        IQueryable<TEntity> List(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> ListBy(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Get(Func<TEntity, bool> where, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetById(TId id, params Expression<Func<TEntity, object>>[] includeProperties);


        IQueryable<TEntity> GetOrderedBy<TKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TKey>> ordem, bool ascendente = true, params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity Create(TEntity entity);
        Task<TEntity> CreateAsync(TEntity entity);
        void CreateList(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
        bool Exists(Func<TEntity, bool> where);
    }
}
