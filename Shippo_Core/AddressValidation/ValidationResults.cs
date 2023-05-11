using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class ValidationResults : ShippoId {
        [JsonProperty(PropertyName = "is_valid")]
        public bool? IsValid { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<ValidationMessage> Messages { get; set; }
    }
}
