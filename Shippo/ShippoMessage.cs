using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    public class ShippoMessage
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
    }
}
