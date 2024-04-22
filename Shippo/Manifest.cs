using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Manifest : ShippoId {
        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "status")]
        public object Status { get; set; }

        [JsonProperty(PropertyName = "provider")]
        public object Provider { get; set; }

        [JsonProperty(PropertyName = "shipment_date")]
        public object ShipmentDate { get; set; }

        [JsonProperty(PropertyName = "address_from")]
        public object AddressFrom { get; set; }

        [JsonProperty(PropertyName = "documents")]
        public object Documents { get; set; }
    }
}

