using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ShortAddress
    {
        [JsonProperty(PropertyName = "city")]
        public string City;

        [JsonProperty(PropertyName = "state")]
        public string State;

        [JsonProperty(PropertyName = "Zip")]
        public string Zip;

        [JsonProperty(PropertyName = "Country")]
        public string Country;
    }
}
