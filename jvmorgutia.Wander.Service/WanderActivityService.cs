using jvmorgutia.Wander.Contract;
using jvmorgutia.Wander.Logic;

namespace jvmorgutia.Wander.Service
{
    public class WanderActivityService
    {
        public ActivityLookupResponse GetLocalActivities(ActivityLookupRequest contract)
        {
            return new WanderActivityLogic().GetLocalActivities(contract);
        }
    }
}
