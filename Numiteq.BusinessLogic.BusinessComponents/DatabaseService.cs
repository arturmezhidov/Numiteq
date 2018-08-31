using Numiteq.BusinessLogic.BusinessContracts;
using Numiteq.DataAccess.DataContracts;

namespace Numiteq.BusinessLogic.BusinessComponents
{
    public class DatabaseService : IDatabaseService
    {
        private IDatabaseInitializer databaseInitializer;

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
