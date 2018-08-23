using System;
using System.Linq;
using System.Linq.Expressions;
using Numiteq.Common.Entities;

namespace Numiteq.DataAccess.DataContracts
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Create(TEntity entity);

        TEntity Update(TEntity entity);

        TEntity Remove(TEntity entity);

        TEntity Remove(object entityId);

        TEntity GetById(object entityId);

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}