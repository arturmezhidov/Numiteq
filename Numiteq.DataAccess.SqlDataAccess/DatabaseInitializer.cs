using System.Collections.Generic;
using Numiteq.DataAccess.DataContracts.Initialization;

namespace Numiteq.DataAccess.SqlDataAccess
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataContext context;
        private readonly IEnumerable<ITableInitializer> initializers;

        public DatabaseInitializer(DataContext context, IEnumerable<ITableInitializer> initializers)
        {
            this.context = context;
            this.initializers = initializers;
        }

        public void Init()
        {
            bool isCreated = context.Database.EnsureCreated();

            if (isCreated)
            {
                foreach (ITableInitializer initializer in initializers)
                {
                    initializer.Init();
                }
            }
        }
    }
}