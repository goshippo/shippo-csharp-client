using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Track : ShippoId {
        [JsonProperty (PropertyName = "carrier")]
        public object Carrier { get; set; }

        [JsonProperty (PropertyName = "tracking_number")]
        public object TrackingNumber { get; set; }

        [JsonProperty (PropertyName = "address_from")]
        public object AddressFrom { get; set; }

        [JsonProperty (PropertyName = "address_to")]
        public object AddressTo { get; set; }

        [JsonProperty (PropertyName = "eta")]
        public object Eta { get; set; }

        [JsonProperty (PropertyName = "servicelevel")]
        public object Servicelevel { get; set; }

        [JsonProperty (PropertyName = "tracking_status")]
        public object TrackingStatus { get; set; }

        [JsonProperty (PropertyName = "tracking_history")]
        public object TrackingHistory { get; set; }

        [JsonProperty (PropertyName = "metadata")]
        public object Metadata { get; set; }
    }
}
