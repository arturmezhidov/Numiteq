using System;
using System.Collections.Generic;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.DataAccess.SqlDataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext context;
        private readonly Dictionary<string, object> repositories;
        private bool disposed;

        public UnitOfWork(DataContext dataContext)
        {
            context = dataContext;
            repositories = new Dictionary<string, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            string key = typeof(TEntity).Name;

            if (!repositories.ContainsKey(key))
            {
                IRepository<TEntity> newRepository = new Repository<TEntity>(context);
                repositories.Add(key, newRepository);
            }

            IRepository<TEntity> repository = (IRepository<TEntity>)repositories[key];
            return repository;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }
    }
}