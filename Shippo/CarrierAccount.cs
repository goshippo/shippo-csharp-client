using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class CarrierAccount : ShippoId {
        [JsonProperty(PropertyName = "account_id")]
        public object AccountId { get; set; }

        [JsonProperty(PropertyName = "carrier")]
        public object Carrier { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public object Parameters { get; set; }

        [JsonProperty(PropertyName = "test")]
        public object Test { get; set; }

        [JsonProperty(PropertyName = "active")]
        public object Active { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }
    }
}

