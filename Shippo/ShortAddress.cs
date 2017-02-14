using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class ShortAddress
    {
        [JsonProperty (PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty (PropertyName = "state")]
        public string State { get; set; }

        [JsonProperty (PropertyName = "Zip")]
        public string Zip { get; set; }

        [JsonProperty (PropertyName = "Country")]
        public string Country { get; set; }
    }
}
