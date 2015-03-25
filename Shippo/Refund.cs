using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Refund : ShippoId {
        [JsonProperty (PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "object_id")]
        public object ObjectId { get; set; }

        [JsonProperty (PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "object_status")]
        public object ObjectStatus { get; set; }

        [JsonProperty (PropertyName = "transaction")]
        public object Transaction { get; set; }

    }
}

