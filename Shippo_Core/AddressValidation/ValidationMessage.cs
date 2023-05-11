using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class ValidationMessage : ShippoId {
        [JsonProperty(PropertyName = "source")]
        public String Source { get; set; }

        [JsonProperty(PropertyName = "code")]
        public String Code { get; set; }

        [JsonProperty(PropertyName = "type")]
        public String Type { get; set; }

        [JsonProperty(PropertyName = "text")]
        public String Text { get; set; }
    }
}
