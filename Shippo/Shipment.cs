using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Shipment : ShippoId {

        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public DateTime ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public DateTime ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public string ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "address_from")]
        public string AddressFrom { get; set; }

        [JsonProperty(PropertyName = "address_to")]
        public string AddressTo { get; set; }

        [JsonProperty(PropertyName = "parcels")]
        public string[] Parcels { get; set; }

        [JsonProperty(PropertyName = "shipment_date")]
        public DateTime ShipmentDate { get; set; }

        [JsonProperty(PropertyName = "address_return")]
        public string AddressReturn { get; set; }

        [JsonProperty(PropertyName = "customs_declaration")]
        public string CustomsDeclaration { get; set; }

        [JsonProperty(PropertyName = "carrier_accounts")]
        public List<string> CarrierAccounts;

        [JsonProperty(PropertyName = "metadata")]
        public string Metadata { get; set; }

        [JsonProperty(PropertyName = "extra")]
        public object Extra { get; set; }

        [JsonProperty(PropertyName = "rates")]
        public Rate[] Rates { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public IEnumerable<ShippoMessage> Messages { get; set; }

        [JsonProperty(PropertyName = "test")]
        public bool? Test;

        [JsonProperty(PropertyName = "rates_url")]
        public string Rates_Url { get; set; }

        [JsonProperty(PropertyName = "insurance_amount")]
        public decimal Insurance_Amount { get; set; }


        public static Shipment createForBatch(Address addressFrom,
                                              Address addressTo, Parcel[] parcels)
        {
            Shipment s = new Shipment();
            s.AddressFrom = addressFrom.ObjectId;
            s.AddressTo = addressTo.ObjectId;
            s.Parcels = parcels?.Select(x => x?.ObjectId)?.ToArray() ?? new string[] { };
            return s;
        }
    }
}

