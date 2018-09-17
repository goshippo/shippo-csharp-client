using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction : ShippoId {
        [JsonProperty(PropertyName = "object_state")]
        public string ObjectState { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public DateTime ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public DateTime ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public string ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "was_test")]
        public bool WasTest { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public string Rate { get; set; }

        [JsonProperty(PropertyName = "tracking_number")]
        public string TrackingNumber { get; set; }

        [JsonProperty(PropertyName = "tracking_status")]
        public IEnumerable<TrackingStatus> TrackingStatus { get; set; }

        [JsonProperty(PropertyName = "tracking_url_provider")]
        public object TrackingUrlProvider { get; set; }

        [JsonProperty(PropertyName = "label_url")]
        public string LabelURL { get; set; }

    	[JsonProperty(PropertyName = "commercial_invoice_url")]
    	public string CommercialInvoiceUrl { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public IEnumerable<ShippoMessage> Messages { get; set; }

        [JsonProperty(PropertyName = "eta")]
        public DateTime ETA { get; set; }

        [JsonProperty(PropertyName = "tracking_history")]
        public IEnumerable<TrackingHistory> Tracking_History { get; set; }


    }
}

