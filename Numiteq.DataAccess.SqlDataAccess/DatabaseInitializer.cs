using Numiteq.DataAccess.DataContracts;

namespace Numiteq.DataAccess.SqlDataAccess
{
    public class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DataContext context;
        private readonly IInitializationDataStorage storage;

        public DatabaseInitializer(DataContext context, IInitializationDataStorage storage)
        {
            this.context = context;
            this.storage = storage;
        }

        public void Init()
        {
            bool isCreated = context.Database.EnsureCreated();

            if (isCreated)
            {
                context.Settings.AddRange(storage.GetSettings());
                context.SaveChanges();
            }
        }
    }
}