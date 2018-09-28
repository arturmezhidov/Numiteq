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

            repository.Add(entity);

            unitOfWork.Save();

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

            repository.AddRange(entities);

            unitOfWork.Save();

            return entities;
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            entity = repository.Update(entity);

            return entity;
        }

        public virtual TEntity Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            repository.Remove(entity);
            unitOfWork.Save();

            return entity;
        }

        public virtual TEntity Remove(object entityId)
        {
            if (entityId == null)
            {
                throw new ArgumentNullException(nameof(entityId));
            }

            TEntity entity = GetById(entityId);

            if (entity != null)
            {
                entity = Remove(entity);
            }

            return entity;
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

        protected void Save()
        {
            unitOfWork.Save();
        }

        protected override void OnDisposing()
        {
            unitOfWork.Dispose();
        }
    }
}
