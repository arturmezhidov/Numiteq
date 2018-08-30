using Microsoft.EntityFrameworkCore;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Numiteq.DataAccess.SqlDataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Items;

        public Repository(DbContext context)
        {
            Context = context;
            Items = context.Set<TEntity>();
        }

        public virtual TEntity Create(TEntity entity)
        {
            Items.Add(entity);
            return entity;
        }

        public virtual TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            Items.Remove(entity);
            return entity;
        }

        public TEntity Remove(object entityId)
        {
            TEntity entity = GetById(entityId);
            if (entity != null)
            {
                Remove(entity);
            }
            return entity;
        }

        public virtual TEntity GetById(object entityId)
        {
            TEntity result = Items.FirstOrDefault(e => entityId.Equals(e.Id));
            return result;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> items = Items.AsNoTracking();
            return items;
        }

        public virtual IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> result = Items.AsNoTracking().Where(predicate);
            return result;
        }
    }
}
