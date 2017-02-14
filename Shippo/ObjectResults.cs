using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class ObjectResults
    {
        [JsonProperty (PropertyName = "purchase_succeeded")]
        public int PurchaseSucceeded { get; set; }

        [JsonProperty (PropertyName = "purchase_failed")]
        public int PurchaseFailed { get; set; }

        [JsonProperty (PropertyName = "creation_failed")]
        public int CreationFailed { get; set; }

        [JsonProperty (PropertyName = "creation_succeeded")]
        public int CreationSucceeded { get; set; }
    }
}
