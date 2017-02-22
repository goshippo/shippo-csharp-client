using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class BatchShipment : ShippoId
    {
        [JsonProperty (PropertyName = "object_status", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectStatus;

        [JsonProperty (PropertyName = "carrier_account", NullValueHandling = NullValueHandling.Ignore)]
        public string CarrierAccount;

        [JsonProperty (PropertyName = "servicelevel_token", NullValueHandling = NullValueHandling.Ignore)]
        public string ServicelevelToken;

        [JsonProperty (PropertyName = "shipment", NullValueHandling = NullValueHandling.Ignore)]
        public Object Shipment;

        [JsonProperty (PropertyName = "transaction", NullValueHandling = NullValueHandling.Ignore)]
        public string Transaction;

        [JsonProperty (PropertyName = "messages", NullValueHandling = NullValueHandling.Ignore)]
        public object Messages;

        [JsonProperty (PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata;

        public static BatchShipment createForBatchShipments (String carrierAccount, string servicelevelToken, Shipment shipment)
        {
            BatchShipment bs = new BatchShipment ();
            bs.CarrierAccount = carrierAccount;
            bs.ServicelevelToken = servicelevelToken;
            bs.Shipment = shipment;
            return bs;
        }

        public override string ToString ()
        {
            return string.Format ("[BatchShipment: ObjectStatus={0}, CarrierAccount={1}, ServicelevelToken={2}, " +
                                  "Shipment={3}, Transaction={4}, Messages={5}, Metadata={6}]", ObjectStatus,
                                  CarrierAccount, ServicelevelToken, Shipment, Transaction, Messages, Metadata);
        }
    }
}
