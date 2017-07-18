using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Transaction : ShippoId {
        [JsonProperty(PropertyName = "object_state")]
        public object ObjectState { get; set; }

        [JsonProperty(PropertyName = "status")]
        public object Status { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUPdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "was_test")]
        public object WasTest { get; set; }

        [JsonProperty(PropertyName = "rate")]
        public object Rate { get; set; }

        [JsonProperty(PropertyName = "tracking_number")]
        public object TrackingNumber { get; set; }

        [JsonProperty(PropertyName = "tracking_status")]
        public object TrackingStatus { get; set; }

        [JsonProperty(PropertyName = "tracking_url_provider")]
        public object TrackingUrlProvider { get; set; }

        [JsonProperty(PropertyName = "label_url")]
        public object LabelURL { get; set; }

    	[JsonProperty(PropertyName = "commercial_invoice_url")]
    	public object CommercialInvoiceUrl { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public object Messages { get; set; }
    }
}

