using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Shipment : ShippoId {

        [JsonProperty (PropertyName = "object_status")]
        public object ObjectStatus { get; set; }

        [JsonProperty (PropertyName = "object_purpose")]
        public object ObjectPurpose { get; set; }

        [JsonProperty (PropertyName = "object_state")]
        public object ObjectState { get; set; }

        [JsonProperty (PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "address_from")]
        public object AddressFrom { get; set; }

        [JsonProperty (PropertyName = "address_to")]
        public object AddressTo { get; set; }

        [JsonProperty (PropertyName = "parcel")]
        public object Parcel { get; set; }

        [JsonProperty (PropertyName = "return_of")]
        public string ReturnOf;

        [JsonProperty (PropertyName = "submission_date")]
        public object SubmissionDate { get; set; }

        [JsonProperty (PropertyName = "address_return")]
        public object AddressReturn { get; set; }

        [JsonProperty (PropertyName = "customs_declaration")]
        public object CustomsDeclaration { get; set; }

        [JsonProperty (PropertyName = "insurance_amount")]
        public object InsuranceAmount { get; set; }

        [JsonProperty (PropertyName = "insurance_currency")]
        public object InsuranceCurrency { get; set; }

        [JsonProperty (PropertyName = "reference_1")]
        public object Reference1 { get; set; }

        [JsonProperty (PropertyName = "reference_2")]
        public object Reference2 { get; set; }

        [JsonProperty (PropertyName = "carrier_accounts")]
        public List<string> CarrierAccounts;

        [JsonProperty (PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty (PropertyName = "extra")]
        public object Extra { get; set; }

        [JsonProperty (PropertyName = "rates_url")]
        public object RatesUrl { get; set; }

        [JsonProperty (PropertyName = "rates_list")]
        public Rate[] RatesList { get; set; }

        [JsonProperty (PropertyName = "messages")]
        public object Messages { get; set; }

        [JsonProperty (PropertyName = "test")]
        public bool? Test;
    }
}

