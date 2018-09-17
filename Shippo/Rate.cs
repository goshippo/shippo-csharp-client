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
        public ServiceLevel Servicelevel { get; set; }

        [JsonProperty(PropertyName = "estimated_days")]
        public object EstimatedDays { get; set; }

        [JsonProperty(PropertyName = "duration_terms")]
        public object DurationTerms { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public object Messages { get; set; }

        [JsonProperty(PropertyName = "zone")]
        public object Zone { get; set; }

        [JsonProperty(PropertyName = "shipment")]
        public string ShipmentId { get; set; }

        [JsonProperty(PropertyName = "insurance")]
        public bool Insurance { get; set; }
        [JsonProperty(PropertyName = "insurance_amount_local")]
        public float Insurance_Amount_Local { get; set; }
        [JsonProperty(PropertyName = "insurance_currency_local")]
        public string Insurance_Currency_Local { get; set; }
        [JsonProperty(PropertyName = "insurance_amount")]
        public float Insurance_Amount { get; set; }
        [JsonProperty(PropertyName = "insurance_currency")]
        public string Insruance_Currency { get; set; }
        [JsonProperty(PropertyName = "carrier_account")]

        public string Carrier_Account { get; set; }

    }

    public class ServiceLevel
    {
        [JsonProperty(PropertyName = "name")]
        public object Name { get; set; }

        [JsonProperty(PropertyName = "token")]
        public object Token { get; set; }

        [JsonProperty(PropertyName = "terms")]
        public object Terms { get; set; }
    }
}
