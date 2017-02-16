using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class BatchShipment : ShippoId
    {
        [JsonProperty (PropertyName = "object_status")]
        public string ObjectStatus;

        [JsonProperty (PropertyName = "carrier_account")]
        public string CarrierAccount;

        [JsonProperty (PropertyName = "servicelevel_token")]
        public string ServicelevelToken;

        [JsonProperty (PropertyName = "shipment")]
        public Object Shipment;

        [JsonProperty (PropertyName = "transaction")]
        public string Transaction;

        [JsonProperty (PropertyName = "messages")]
        public List<String> Messages;

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata;

        public override string ToString ()
        {
            return string.Format ("[BatchShipment: ObjectStatus={0}, CarrierAccount={1}, ServicelevelToken={2}, " +
                                  "Shipment={3}, Transaction={4}, Messages={5}, Metadata={6}]", ObjectStatus,
                                  CarrierAccount, ServicelevelToken, Shipment, Transaction, Messages, Metadata);
        }
    }
}
