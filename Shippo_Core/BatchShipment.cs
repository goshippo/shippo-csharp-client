using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class BatchShipment : ShippoId
    {
        [JsonProperty(PropertyName = "status")]
        public string Status;

        [JsonProperty(PropertyName = "carrier_account")]
        public string CarrierAccount;

        [JsonProperty(PropertyName = "servicelevel_token")]
        public string ServicelevelToken;

        [JsonProperty(PropertyName = "shipment")]
        public Object Shipment;

        [JsonProperty(PropertyName = "transaction")]
        public string Transaction;

        [JsonProperty(PropertyName = "messages")]
        public object Messages;

        [JsonProperty(PropertyName = "metadata")]
        public string Metadata;

        public static BatchShipment createForBatchShipments(String carrierAccount, string servicelevelToken, Shipment shipment)
        {
            BatchShipment bs = new BatchShipment();
            bs.CarrierAccount = carrierAccount;
            bs.ServicelevelToken = servicelevelToken;
            bs.Shipment = shipment;
            return bs;
        }

        public override string ToString()
        {
            return string.Format("[BatchShipment: Status={0}, CarrierAccount={1}, ServicelevelToken={2}, " +
                                 "Shipment={3}, Transaction={4}, Messages={5}, Metadata={6}]", Status,
                                 CarrierAccount, ServicelevelToken, Shipment, Transaction, Messages, Metadata);
        }
    }
}
