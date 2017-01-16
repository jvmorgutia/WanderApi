using System.Collections.Generic;
using System.Runtime.Serialization;
namespace jvmorgutia.Wander.Contract
{
	[DataContract]
	public class WanderZoneResponseContract
	{
		[DataMember]
		public IEnumerable<WanderActivity> ActivtyList { get; set; }

		[DataMember]
		public WanderZoneRequestContract Request { get; set; }

	}
}
