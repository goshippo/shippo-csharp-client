using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Batch : ShippoId {
        [JsonProperty (PropertyName = "object_status")]
        public string ObjectStatus { get; set; }

        [JsonProperty (PropertyName = "object_created")]
        public string ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated")]
        public string ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "object_owner")]
        public string ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "default_carrier_account")]
        public string DefaultCarrierAccount { get; set; }

        [JsonProperty (PropertyName = "default_servicelevel_token")]
        public string DefaultServicelevelToken { get; set; }

        [JsonProperty (PropertyName = "label_filetype")]
        public string LabelFiletype { get; set; }

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata { get; set; }

        [JsonProperty (PropertyName = "batch_shipments")]
        public BatchShipments BatchShipments { get; set; }

        [JsonProperty (PropertyName = "label_url")]
        public List<String> LabelUrl { get; set; }

        [JsonProperty (PropertyName = "object_results")]
        public ObjectResults ObjectResults { get; set; }
    }
}
