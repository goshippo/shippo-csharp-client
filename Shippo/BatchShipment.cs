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

        public override string ToString ()
        {
            return string.Format ("[BatchShipment: ObjectStatus={0}, CarrierAccount={1}, ServicelevelToken={2}, " +
                                  "Shipment={3}, Transaction={4}, Messages={5}, Metadata={6}]", ObjectStatus,
                                  CarrierAccount, ServicelevelToken, Shipment, Transaction, Messages, Metadata);
        }
    }
}
