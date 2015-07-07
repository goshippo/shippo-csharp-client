using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Rate : ShippoId {
        [JsonProperty (PropertyName = "object_state")]
        public object ObjectState { get; set; }

        [JsonProperty (PropertyName = "object_purpose")]
        public object ObjectPurpose { get; set; }

        [JsonProperty (PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "attributes")]
        public object Attributes { get; set; }

        [JsonProperty (PropertyName = "amount_local")]
        public object AmountLocal { get; set; }

        [JsonProperty (PropertyName = "currency_local")]
        public object CurrencyLocal { get; set; }

        [JsonProperty (PropertyName = "amount")]
        public object Amount { get; set; }

        [JsonProperty (PropertyName = "currency")]
        public object Currency { get; set; }

        [JsonProperty (PropertyName = "provider")]
        public object Provider { get; set; }

        [JsonProperty (PropertyName = "provider_image_75")]
        public object ProviderImage75 { get; set; }

        [JsonProperty (PropertyName = "provider_image_200")]
        public object ProviderImage200 { get; set; }

        [JsonProperty (PropertyName = "servicelevel_name")]
        public object ServicelevelName { get; set; }

        [JsonProperty (PropertyName = "servicelevel_terms")]
        public object ServicelevelTerms { get; set; }

        [JsonProperty (PropertyName = "days")]
        public object Days { get; set; }

        [JsonProperty (PropertyName = "duration_terms")]
        public object DurationTerms { get; set; }

        [JsonProperty (PropertyName = "trackable")]
        public object Trackable { get; set; }

        [JsonProperty (PropertyName = "insurance")]
        public object Insurance { get; set; }

        [JsonProperty (PropertyName = "insurance_amount_local")]
        public object InsuranceAmountLocal { get; set; }

        [JsonProperty (PropertyName = "insurance_currency_local")]
        public object InsuranceCurrencyLocal { get; set; }

        [JsonProperty (PropertyName = "insurance_amount")]
        public object InsuranceAmount { get; set; }

        [JsonProperty (PropertyName = "insurance_currency")]
        public object InsuranceCurrency { get; set; }

        [JsonProperty (PropertyName = "messages")]
        public object Messages { get; set; }

    }
}
