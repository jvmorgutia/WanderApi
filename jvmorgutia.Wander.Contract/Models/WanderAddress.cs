using System;
using System.Runtime.Serialization;

namespace jvmorgutia.Wander.Contract.Models
{
    [DataContract]
    [Serializable]
    public class WanderAddress
    {
        [DataMember]
        public int WanderAddressId { get; set; }

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

        public WanderAddress(int wanderAddressId)
        {
            WanderAddressId = wanderAddressId;
        }
    }
}