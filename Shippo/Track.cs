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
        public DateTime? Eta { get; set; }

        [JsonProperty (PropertyName = "servicelevel")]
        public Servicelevel Servicelevel { get; set; }

        [JsonProperty (PropertyName = "tracking_status")]
        public TrackingStatus TrackingStatus { get; set; }

        [JsonProperty (PropertyName = "tracking_history")]
        public List<TrackingHistory> TrackingHistory { get; set; }

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata { get; set; }

        public override string ToString ()
        {
            return string.Format ("[Track: Carrier={0}, TrackingNumber={1}, AddressFrom={2}, AddressTo={3}, Eta={4}," +
                                  "Servicelevel={5}, TrackingStatus={6}, TrackingHistory={7}, Metadata={8}]",Carrier,
                                  TrackingNumber, AddressFrom, AddressTo, Eta, Servicelevel, TrackingStatus,
                                  TrackingHistory, Metadata);
        }
    }
}
