using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class UserParcelTemplate : ShippoId {
        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }
        
        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "name")]
        public object Name { get; set; }

        [JsonProperty(PropertyName = "length")]
        public object Length { get; set; }

        [JsonProperty(PropertyName = "width")]
        public object Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public object Height { get; set; }

        [JsonProperty(PropertyName = "distance_unit")]
        public object DistanceUnit { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public object Weight { get; set; }

        [JsonProperty(PropertyName = "weight_unit")]
        public object WeightUnit { get; set; }
    }
}

