using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class BatchShipments
    {
        [JsonProperty (PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty (PropertyName = "next")]
        public string Next { get; set; }

        [JsonProperty (PropertyName = "previous")]
        public string Previous { get; set; }

        [JsonProperty (PropertyName = "results")]
        public List<BatchShipment> Results { get; set; }
    }
}
