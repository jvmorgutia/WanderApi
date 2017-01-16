using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;

namespace jvmorgutia.Wander.Contract.Models
{
	[DataContract]
	[Serializable]
	public class WanderActivity
	{
		[DataMember]
		public Bitmap Image { get; set; }

		[DataMember]
		public string Title { get; set; }

		[DataMember]
		public string Subtitle { get; set; }

		[DataMember]
		public string Description { get; set; }

		[DataMember]
		public IEnumerable<WanderTag> Tags { get; set; }

		[DataMember]
		public WanderAddress Address { get; set; }
	}
}
