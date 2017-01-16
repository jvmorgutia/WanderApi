using System;
using System.Runtime.Serialization;
namespace jvmorgutia.Wander.Contract
{
	[DataContract]
	[Serializable]
	public class WanderTag
	{
		[DataMember]
		public int Id { get; set; }

		[DataMember]
		public Enumerations.TagColor Color { get; set; }

		[DataMember]
		public string Description { get; set; }
	}
}
