using System;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public abstract class Disposable
    {
        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void OnDisposing();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    OnDisposing();
                }
                _disposed = true;
            }
        }
    }
}
