using System.Runtime.Serialization;
using System;
namespace jvmorgutia.Wander.Contract
{
	[DataContract]
	[Serializable]
	public class WanderAddress
	{
		[DataMember]
		public string Address { get; set; }

		[DataMember]
		public string Address2 { get; set; }

		[DataMember]
		public string CrossStreet { get; set; }

		[DataMember]
		public string ZipCode { get; set; }

		[DataMember]
		public string Latitude { get; set; }

		[DataMember]
		public string Longitude { get; set; }
	}
}