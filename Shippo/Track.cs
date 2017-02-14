using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Track : ShippoId {
        [JsonProperty (PropertyName = "carrier")]
        public string Carrier { get; set; }

        [JsonProperty (PropertyName = "tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty (PropertyName = "address_from")]
        public ShortAddress AddressFrom { get; set; }

        [JsonProperty (PropertyName = "address_to")]
        public ShortAddress AddressTo { get; set; }

        [JsonProperty (PropertyName = "eta")]
        public string Eta { get; set; }

        [JsonProperty (PropertyName = "servicelevel")]
        public Servicelevel Servicelevel { get; set; }

        [JsonProperty (PropertyName = "tracking_status")]
        public TrackingStatus TrackingStatus { get; set; }

        [JsonProperty (PropertyName = "tracking_history")]
        public List<Hashtable> TrackingHistory { get; set; }

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata { get; set; }
    }
}
