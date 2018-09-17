using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Manifest : ShippoId {
        [JsonProperty(PropertyName = "object_created")]
        public DateTime ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public DateTime ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public string ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "provider")]
        public object Provider { get; set; }

        [JsonProperty(PropertyName = "submission_date")]
        public DateTime SubmissionDate { get; set; }

        [JsonProperty(PropertyName = "address_from")]
        public object AddressFrom { get; set; }

        [JsonProperty(PropertyName = "documents")]
        public List<string> Documents { get; set; }

        [JsonProperty(PropertyName = "carrier_account")]
        public string Carrier_Account { get; set; }
    }
}

