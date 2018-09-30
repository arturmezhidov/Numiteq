using System;
using System.Collections.Generic;
using System.Linq;
using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.Common.Entities;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class DataService<TEntity> : Disposable, IDataService<TEntity> where TEntity : BaseEntity
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<TEntity> repository;

        public DataService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repository = unitOfWork.GetRepository<TEntity>();
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity = repository.Add(entity);

            Save();

            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (!entities.Any())
            {
                return entities;
            }

            entities = repository.AddRange(entities);

            Save();

            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity = repository.Update(entity);

            Save();

            return entity;
        }

        public IEnumerable<TEntity> UpdateRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (!entities.Any())
            {
                return entities;
            }

            entities = repository.UpdateRange(entities);

            Save();

            return entities;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity = repository.Remove(entity);

            Save();

            return entity;
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            if (!entities.Any())
            {
                return entities;
            }

            entities = repository.RemoveRange(entities);

            Save();

            return entities;
        }

        public virtual TEntity Remove(object entityId)
        {
            if (entityId == null)
            {
                throw new ArgumentNullException(nameof(entityId));
            }

            TEntity entity = repository.Remove(entityId);

            Save();

            return entity;
        }

        public IEnumerable<TEntity> RemoveRange(IEnumerable<object> entityIds)
        {
            if (entityIds == null)
            {
                throw new ArgumentNullException(nameof(entityIds));
            }

            if (!entityIds.Any())
            {
                return new List<TEntity>();
            }

            var entities = repository.Find(i => entityIds.Contains(i.Id));
            var deletedEntities = RemoveRange(entities);

            return entities;
        }

        public virtual TEntity GetById(object entityId)
        {
            if (entityId == null)
            {
                throw new ArgumentNullException(nameof(entityId));
            }

            TEntity entity = repository.GetById(entityId);

            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            IQueryable<TEntity> result = repository.GetAll();
            return result;
        }

        protected virtual void Save()
        {
            unitOfWork.Save();
        }

        protected override void OnDisposing()
        {
            unitOfWork.Dispose();
        }
    }
}