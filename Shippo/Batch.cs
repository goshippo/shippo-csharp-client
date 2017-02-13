using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Batch : ShippoId {
        [JsonProperty (PropertyName = "object_status")]
        public object ObjectStatus { get; set; }

        [JsonProperty (PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "default_carrier_account")]
        public object DefaultCarrierAccount { get; set; }

        [JsonProperty (PropertyName = "default_servicelevel_token")]
        public object DefaultServicelevelToken { get; set; }

        [JsonProperty (PropertyName = "label_filetype")]
        public object LabelFiletype { get; set; }

        [JsonProperty (PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty (PropertyName = "batch_shipments")]
        public object BatchShipments { get; set; }

        [JsonProperty (PropertyName = "label_url")]
        public object LabelUrl { get; set; }

        [JsonProperty (PropertyName = "object_results")]
        public object ObjectResults { get; set; }
    }
}
