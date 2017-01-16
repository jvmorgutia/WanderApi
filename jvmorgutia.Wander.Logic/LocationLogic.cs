using jvmorgutia.Wander.Contract;

namespace jvmorgutia.Wander.Logic
{
	public class LocationLogic
	{
		public LocationLogic()
		{
		}
		public WanderZoneResponseContract GetZoneActivities(WanderZoneRequestContract contract)
		{
			//TODO do stuff
			return new WanderZoneResponseContract { Request = contract };
		}
	}
}

