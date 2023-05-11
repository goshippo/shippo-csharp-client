using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BatchShipments
    {
        [JsonProperty(PropertyName = "count")]
        public int Count;

        [JsonProperty(PropertyName = "next")]
        public string Next;

        [JsonProperty(PropertyName = "previous")]
        public string Previous;

        [JsonProperty(PropertyName = "results")]
        public List<BatchShipment> Results;

        public override string ToString()
        {
            return string.Format("[BatchShipments: Count={0}, Next={1}, Previous={2}, Results={3}]",
                                 Count, Next, Previous, Results);
        }
    }
}
