using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Rate : ShippoId {
        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public object Attributes { get; set; }

        [JsonProperty(PropertyName = "amount_local")]
        public object AmountLocal { get; set; }

        [JsonProperty(PropertyName = "currency_local")]
        public object CurrencyLocal { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public object Amount { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public object Currency { get; set; }

        [JsonProperty(PropertyName = "provider")]
        public object Provider { get; set; }

        [JsonProperty(PropertyName = "provider_image_75")]
        public object ProviderImage75 { get; set; }

        [JsonProperty(PropertyName = "provider_image_200")]
        public object ProviderImage200 { get; set; }

        [JsonProperty(PropertyName = "servicelevel")]
        public object Servicelevel { get; set; }

        [JsonProperty(PropertyName = "days")]
        public object Days { get; set; }

        [JsonProperty(PropertyName = "duration_terms")]
        public object DurationTerms { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public object Messages { get; set; }

        [JsonProperty(PropertyName = "zone")]
        public object Zone { get; set; }

    }
}
