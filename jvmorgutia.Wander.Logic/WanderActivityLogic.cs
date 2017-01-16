using jvmorgutia.Wander.Contract;

namespace jvmorgutia.Wander.Logic
{
	public class WanderActivityLogic
	{
		public ActivityLookupResponse GetLocalActivities(ActivityLookupRequest contract)
		{
            //TODO call DataAccess from here
			return new ActivityLookupResponse { Request = contract };
		}
	}
}

