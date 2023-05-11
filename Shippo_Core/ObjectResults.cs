using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ObjectResults
    {
        [JsonProperty(PropertyName = "purchase_succeeded")]
        public int PurchaseSucceeded;

        [JsonProperty(PropertyName = "purchase_failed")]
        public int PurchaseFailed;

        [JsonProperty(PropertyName = "creation_failed")]
        public int CreationFailed;

        [JsonProperty(PropertyName = "creation_succeeded")]
        public int CreationSucceeded;

        public override string ToString()
        {
            return string.Format("[ObjectResults: PurchaseSucceeded={0}, PurchaseFailed={1}, CreationFailed={2}," +
                                 "CreationSucceeded={3}]", PurchaseSucceeded, PurchaseFailed, CreationFailed,
                                 CreationSucceeded);
        }
    }
}
