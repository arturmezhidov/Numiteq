using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.DataAccess.DataContracts.Initialization;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IDatabaseInitializer databaseInitializer;

        public DatabaseService(IDatabaseInitializer databaseInitializer)
        {
            this.databaseInitializer = databaseInitializer;
        }

        public void InitDatabase()
        {
            databaseInitializer.Init();
        }
    }
}