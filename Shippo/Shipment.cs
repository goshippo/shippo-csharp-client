using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Shipment : ShippoId {

        [JsonProperty (PropertyName = "object_status")]
        public string ObjectStatus;

        [JsonProperty (PropertyName = "object_purpose")]
        public string ObjectPurpose;

        [JsonProperty (PropertyName = "object_state")]
        public string ObjectState;

        [JsonProperty (PropertyName = "object_created")]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "object_updated")]
        public DateTime? ObjectUpdated;

        [JsonProperty (PropertyName = "object_owner")]
        public string ObjectOwner;

        [JsonProperty (PropertyName = "address_from")]
        public string AddressFrom;

        [JsonProperty (PropertyName = "address_to")]
        public string AddressTo;

        [JsonProperty (PropertyName = "parcel")]
        public string Parcel;

        [JsonProperty (PropertyName = "return_of")]
        public string ReturnOf;

        [JsonProperty (PropertyName = "submission_date")]
        public DateTime? SubmissionDate;

        [JsonProperty (PropertyName = "address_return")]
        public string AddressReturn;

        [JsonProperty (PropertyName = "customs_declaration")]
        public string CustomsDeclaration;

        [JsonProperty (PropertyName = "insurance_amount")]
        public double InsuranceAmount;

        [JsonProperty (PropertyName = "insurance_currency")]
        public string InsuranceCurrency;

        [JsonProperty (PropertyName = "reference_1")]
        public string Reference1;

        [JsonProperty (PropertyName = "reference_2")]
        public string Reference2;

        [JsonProperty (PropertyName = "carrier_accounts")]
        public List<string> CarrierAccounts;

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata;

        [JsonProperty (PropertyName = "extra")]
        public object Extra;

        [JsonProperty (PropertyName = "rates_url")]
        public string RatesUrl;

        [JsonProperty (PropertyName = "rates_list")]
        public List<Rate> RatesList;

        [JsonProperty (PropertyName = "messages")]
        public List<string> Messages;

        [JsonProperty (PropertyName = "test")]
        public bool Test;
    }
}

