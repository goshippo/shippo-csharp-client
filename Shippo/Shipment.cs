using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Shipment : ShippoId {

        [JsonProperty (PropertyName = "object_status", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectStatus { get; set; }

        [JsonProperty (PropertyName = "object_purpose", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectPurpose { get; set; }

        [JsonProperty (PropertyName = "object_state", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectState { get; set; }

        [JsonProperty (PropertyName = "object_created", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "object_owner", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "address_from", NullValueHandling = NullValueHandling.Ignore)]
        public object AddressFrom { get; set; }

        [JsonProperty (PropertyName = "address_to", NullValueHandling = NullValueHandling.Ignore)]
        public object AddressTo { get; set; }

        [JsonProperty (PropertyName = "parcel", NullValueHandling = NullValueHandling.Ignore)]
        public object Parcel { get; set; }

        [JsonProperty (PropertyName = "submission_type", NullValueHandling = NullValueHandling.Ignore)]
        public object SubmissionType { get; set; }

        [JsonProperty (PropertyName = "return_of", NullValueHandling = NullValueHandling.Ignore)]
        public string ReturnOf;

        [JsonProperty (PropertyName = "submission_date", NullValueHandling = NullValueHandling.Ignore)]
        public object SubmissionDate { get; set; }

        [JsonProperty (PropertyName = "address_return", NullValueHandling = NullValueHandling.Ignore)]
        public object AddressReturn { get; set; }

        [JsonProperty (PropertyName = "customs_declaration", NullValueHandling = NullValueHandling.Ignore)]
        public object CustomsDeclaration { get; set; }

        [JsonProperty (PropertyName = "insurance_amount", NullValueHandling = NullValueHandling.Ignore)]
        public object InsuranceAmount { get; set; }

        [JsonProperty (PropertyName = "insurance_currency", NullValueHandling = NullValueHandling.Ignore)]
        public object InsuranceCurrency { get; set; }

        [JsonProperty (PropertyName = "reference_1", NullValueHandling = NullValueHandling.Ignore)]
        public object Reference1 { get; set; }

        [JsonProperty (PropertyName = "reference_2", NullValueHandling = NullValueHandling.Ignore)]
        public object Reference2 { get; set; }

        [JsonProperty (PropertyName = "carrier_accounts", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CarrierAccounts;

        [JsonProperty (PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        [JsonProperty (PropertyName = "extra", NullValueHandling = NullValueHandling.Ignore)]
        public object Extra { get; set; }

        [JsonProperty (PropertyName = "rates_url", NullValueHandling = NullValueHandling.Ignore)]
        public object RatesUrl { get; set; }

        [JsonProperty (PropertyName = "rates_list", NullValueHandling = NullValueHandling.Ignore)]
        public Rate[] RatesList { get; set; }

        [JsonProperty (PropertyName = "messages", NullValueHandling = NullValueHandling.Ignore)]
        public object Messages { get; set; }

        [JsonProperty (PropertyName = "test", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Test;

        public static Shipment createForBatch (ShippoEnums.ObjectPurposes purpose, Address addressFrom,
                                               Address addressTo, Parcel parcel)
        {
            Shipment s = new Shipment ();
            s.ObjectPurpose = purpose;
            s.AddressFrom = addressFrom;
            s.AddressTo = addressTo;
            s.Parcel = parcel;
            return s;
        }
    }
}

