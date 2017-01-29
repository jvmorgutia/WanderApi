using System.Collections.Generic;
using jvmorgutia.Wander.Contract.Models;
using jvmorgutia.Wander.Data.DataConnection;
using jvmorgutia.Wander.Data.DataContext;

namespace jvmorgutia.Wander.Data
{
    public class LocationRepository : BaseRepository
    {

        public List<WanderActivity> Get(int zip, int radius)
        {
            return new WanderDataContext().Initialize<GetActivityDataWithZip>()
                .SetParameters(zip, radius)
                .ExecuteDataModelList();
        }

        public List<WanderActivity> Get(float lattitude, float longitude, int radius)
        {
            return new List<WanderActivity>(); 
        }
    }
}
