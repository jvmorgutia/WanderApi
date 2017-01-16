using jvmorgutia.Wander.Contract;
using jvmorgutia.Wander.Logic;

namespace jvmorgutia.Wander.Service
{
	public class LocationService
	{
		public WanderZoneResponseContract GetWanderZones(WanderZoneRequestContract contract)
		{
			return new LocationLogic().GetZoneActivities(contract);
			}
	}
}
