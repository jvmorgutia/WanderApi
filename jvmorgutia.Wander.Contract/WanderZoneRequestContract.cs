using System.Runtime.Serialization;

namespace jvmorgutia.Wander.Contract
{
	[DataContract]
	public class WanderZoneRequestContract
	{
		[DataMember]
		public long Latitude { get; set; }

		[DataMember]
		public long Longitude { get; set; }

		[DataMember]
		public int Radius { get; set; }

		[DataMember]
		public int ZipCode { get; set; }
	}
}
