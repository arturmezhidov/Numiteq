using Numiteq.DataAccess.DataContracts;

namespace Numiteq.DataAccess.SqlDataAccess
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataContext context;

        public DatabaseInitializer(DataContext context)
        {
            this.context = context;
        }

        public void Init()
        {
            bool isCreated = context.Database.EnsureCreated();

            if (isCreated)
            {
                // TODO: init data
            }
        }
    }
}