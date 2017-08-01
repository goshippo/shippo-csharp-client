using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BatchShipments
    {
        [JsonProperty(PropertyName = "next")]
        public string Next;

        [JsonProperty(PropertyName = "previous")]
        public string Previous;

        [JsonProperty(PropertyName = "results")]
        public List<BatchShipment> Results;

        public override string ToString()
        {
            return string.Format("[BatchShipments: Next={0}, Previous={1}, Results={2}]",
                                 Next, Previous, Results);
        }
    }
}
