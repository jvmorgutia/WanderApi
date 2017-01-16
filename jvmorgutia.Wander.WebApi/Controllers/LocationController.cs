using System.Web.Http;
using jvmorgutia.Wander.Contract;
using jvmorgutia.Wander.Service;

namespace jvmorgutia.Wander.WebApi.Controllers
{
	public class LocationController : ApiController
	{
		[HttpGet, ActionName("GetWanderZone")]
		public WanderZoneResponseContract GetWanderZones(WanderZoneRequestContract contract)
		{
			return new LocationService().GetWanderZones(contract);
		}
	}
}

