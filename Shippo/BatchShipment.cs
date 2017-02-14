using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class BatchShipment : ShippoId
    {
        [JsonProperty (PropertyName = "object_status")]
        public string ObjectStatus { get; set; }

        [JsonProperty (PropertyName = "carrier_account")]
        public string CarrierAccount { get; set; }

        [JsonProperty (PropertyName = "servicelevel_token")]
        public string ServicelevelToken { get; set; }

        [JsonProperty (PropertyName = "shipment")]
        public Object Shipment { get; set; }

        [JsonProperty (PropertyName = "transaction")]
        public string Transaction { get; set; }

        [JsonProperty (PropertyName = "messages")]
        public List<String> Messages { get; set; }

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata { get; set; }
    }
}
