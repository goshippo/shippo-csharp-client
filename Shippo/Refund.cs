using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Refund : ShippoId {
        [JsonProperty(PropertyName = "object_created")]
        public DateTime ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public DateTime ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public string ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "transaction")]
        public string Transaction { get; set; }

    }
}

