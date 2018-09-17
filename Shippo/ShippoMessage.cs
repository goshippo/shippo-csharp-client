using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    public class ShippoMessage
    {
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
