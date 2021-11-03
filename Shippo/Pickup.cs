using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Pickup : ShippoId {
        [JsonProperty(PropertyName = "object_id")]
        public object ObjectId { get; set; }

        [JsonProperty(PropertyName = "carrier_account")]
        public object CarrierAccount { get; set; }

        [JsonProperty(PropertyName = "location")]
        public object Location { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public object Transactions { get; set; }

        [JsonProperty(PropertyName = "requested_start_time")]
        public object RequestedStartTime { get; set; }

        [JsonProperty(PropertyName = "requested_end_time")]
        public object RequestedEndTime { get; set; }

        [JsonProperty(PropertyName = "confirmed_start_time")]
        public object ConfirmedStartTime { get; set; }

        [JsonProperty(PropertyName = "confirmed_end_time")]
        public object ConfirmedEndTime { get; set; }

        [JsonProperty(PropertyName = "cancel_by_time")]
        public object CancelByTime { get; set; }

        [JsonProperty(PropertyName = "status")]
        public object Status { get; set; }

        [JsonProperty(PropertyName = "confirmation_code")]
        public object ConfirmationCode { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public object TimeZone { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public object Messages { get; set; }

        [JsonProperty(PropertyName = "is_test")]
        public object IsTest { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }
    }
}

