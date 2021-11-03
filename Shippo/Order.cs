using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Order : ShippoId {
        [JsonProperty(PropertyName = "object_id")]
        public object ObjectId { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "order_number")]
        public object OrderNumber { get; set; }

        [JsonProperty(PropertyName = "order_status")]
        public object OrderStatus { get; set; }

        [JsonProperty(PropertyName = "placed_at")]
        public object PlacedAt { get; set; }

        [JsonProperty(PropertyName = "to_address")]
        public object ToAddress { get; set; }

        [JsonProperty(PropertyName = "from_address")]
        public object FromAddress { get; set; }

        [JsonProperty(PropertyName = "line_items")]
        public object LineItems { get; set; }

        [JsonProperty(PropertyName = "shipping_cost")]
        public object ShippingCost { get; set; }

        [JsonProperty(PropertyName = "shipping_cost_currency")]
        public object ShippingCostCurrency { get; set; }

        [JsonProperty(PropertyName = "shipping_method")]
        public object ShippingMethod { get; set; }

        [JsonProperty(PropertyName = "shop_app")]
        public object ShopApp { get; set; }

        [JsonProperty(PropertyName = "subtotal_price")]
        public object SubtotalPrice { get; set; }

        [JsonProperty(PropertyName = "total_price")]
        public object TotalPrice { get; set; }

        [JsonProperty(PropertyName = "total_tax")]
        public object TotalTax { get; set; }

        [JsonProperty(PropertyName = "currency")]
        public object Currency { get; set; }

        [JsonProperty(PropertyName = "transactions")]
        public object Transactions { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public object Weight { get; set; }

        [JsonProperty(PropertyName = "weight_unit")]
        public object WeightUnit { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public object Notes { get; set; }

        [JsonProperty(PropertyName = "test")]
        public object Test { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }
    }
}

