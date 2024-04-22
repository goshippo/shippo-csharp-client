using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Track : ShippoId
    {
        [JsonProperty(PropertyName = "carrier")]
        public string Carrier;

        [JsonProperty(PropertyName = "tracking_number")]
        public string TrackingNumber;

        [JsonProperty(PropertyName = "address_from")]
        public ShortAddress AddressFrom;

        [JsonProperty(PropertyName = "address_to")]
        public ShortAddress AddressTo;

        [JsonProperty(PropertyName = "eta")]
        public DateTime? Eta;

        [JsonProperty(PropertyName = "servicelevel")]
        public Servicelevel Servicelevel;

        [JsonProperty(PropertyName = "tracking_status")]
        public TrackingStatus TrackingStatus;

        [JsonProperty(PropertyName = "tracking_history")]
        public List<TrackingHistory> TrackingHistory;

        [JsonProperty(PropertyName = "metadata")]
        public string Metadata;

        public override string ToString()
        {
            return string.Format("[Track: Carrier={0}, TrackingNumber={1}, AddressFrom={2}, AddressTo={3}, Eta={4}," +
                                 "Servicelevel={5}, TrackingStatus={6}, TrackingHistory={7}, Metadata={8}]",Carrier,
                                 TrackingNumber, AddressFrom, AddressTo, Eta, Servicelevel, TrackingStatus,
                                 TrackingHistory, Metadata);
        }
    }
}
