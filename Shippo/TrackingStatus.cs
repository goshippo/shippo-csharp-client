using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class TrackingStatus : ShippoId
    {
        [JsonProperty (PropertyName = "object_created")]
        public string ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated")]
        public string ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty (PropertyName = "status_details")]
        public string StatusDetails { get; set; }

        [JsonProperty (PropertyName = "status_date")]
        public string StatusDate { get; set; }

        [JsonProperty (PropertyName = "location")]
        public ShortAddress location { get; set; }
    }
}
