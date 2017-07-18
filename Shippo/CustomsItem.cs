using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class CustomsItem : ShippoId {
        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUPdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "object_state")]
        public object ObjectState { get; set; }

        [JsonProperty(PropertyName = "description")]
        public object Description { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public object Quantity { get; set; }

        [JsonProperty(PropertyName = "net_weight")]
        public object NetWeight { get; set; }

        [JsonProperty(PropertyName = "mass_unit")]
        public object MassUnit { get; set; }

        [JsonProperty(PropertyName = "value_amount")]
        public object ValueAmount { get; set; }

        [JsonProperty(PropertyName = "value_currency")]
        public object ValueCurrency { get; set; }

        [JsonProperty(PropertyName = "tariff_number")]
        public object TariffNumber { get; set; }

        [JsonProperty(PropertyName = "origin_country")]
        public object OriginCountry { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }
    }
}

