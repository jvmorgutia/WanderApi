using jvmorgutia.Wander.Data.DataConnection;

namespace jvmorgutia.Wander.Data.DataContext
{
    public class WanderDataContext
    {
        public TDataConnection Initialize<TDataConnection>() where TDataConnection : IDataConnection, new()
        {
            return new TDataConnection();
        }


    }
}
