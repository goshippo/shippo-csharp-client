using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Parcel : ShippoId {
        [JsonProperty (PropertyName = "object_state")]
        public string ObjectState;

        [JsonProperty (PropertyName = "object_created")]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "object_updated")]
        public DateTime? ObjectUpdaed;

        [JsonProperty (PropertyName = "object_owner")]
        public string ObjectOwner;

        [JsonProperty (PropertyName = "length")]
        public float Length;

        [JsonProperty (PropertyName = "width")]
        public float Width;

        [JsonProperty (PropertyName = "height")]
        public float Height;

        [JsonProperty (PropertyName = "distance_unit")]
        public string DistanceUnit;

        [JsonProperty (PropertyName = "weight")]
        public float Weight;

        [JsonProperty (PropertyName = "mass_unit")]
        public string MassUnit;

        [JsonProperty (PropertyName = "template")]
        public string Template;

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata;

        [JsonProperty (PropertyName = "extra")]
        public Object Extra;

        [JsonProperty (PropertyName = "test")]
        public bool Test;
    }
}