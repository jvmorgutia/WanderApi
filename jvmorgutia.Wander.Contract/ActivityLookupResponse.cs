using System.Collections.Generic;
using System.Runtime.Serialization;
using jvmorgutia.Wander.Contract.Models;

namespace jvmorgutia.Wander.Contract
{
	[DataContract]
	public class ActivityLookupResponse
	{
		[DataMember]
		public IEnumerable<WanderActivity> ActivtyList { get; set; }

		[DataMember]
		public ActivityLookupRequest Request { get; set; }
	}
}
