using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.DataAccess.SqlDataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> Items;

        public Repository(DbContext context)
        {
            Context = context;
            Items = context.Set<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            Items.Add(entity);
            return entity;
        }

        public virtual IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            Items.AddRange(entities);
            return entities;
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
            TEntity result = Items.Find(entityId);
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