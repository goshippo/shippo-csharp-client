using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Shipment : ShippoId {

        [JsonProperty(PropertyName = "status")]
        public object Status { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "address_from")]
        public object AddressFrom { get; set; }

        [JsonProperty(PropertyName = "address_to")]
        public object AddressTo { get; set; }

        [JsonProperty(PropertyName = "parcels")]
        public object[] Parcels { get; set; }

        [JsonProperty(PropertyName = "shipment_date")]
        public object ShipmentDate { get; set; }

        [JsonProperty(PropertyName = "address_return")]
        public object AddressReturn { get; set; }

        [JsonProperty(PropertyName = "customs_declaration")]
        public object CustomsDeclaration { get; set; }

        [JsonProperty(PropertyName = "carrier_accounts")]
        public List<string> CarrierAccounts;

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(PropertyName = "extra")]
        public object Extra { get; set; }

        [JsonProperty(PropertyName = "rates")]
        public Rate[] Rates { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public object Messages { get; set; }

        [JsonProperty(PropertyName = "test")]
        public bool? Test;

        public static Shipment createForBatch(Address addressFrom,
                                              Address addressTo, Parcel[] parcels)
        {
            Shipment s = new Shipment();
            s.AddressFrom = addressFrom;
            s.AddressTo = addressTo;
            s.Parcels = parcels;
            return s;
        }
    }
}

