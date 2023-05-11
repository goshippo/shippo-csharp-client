using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Parcel : ShippoId
    {
        [JsonProperty(PropertyName = "object_state")]
        public object ObjectState { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUpdaed { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

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

        [JsonProperty(PropertyName = "mass_unit")]
        public object MassUnit { get; set; }

        [JsonProperty(PropertyName = "template")]
        public string Template;

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(PropertyName = "extra")]
        public object Extra;

        [JsonProperty(PropertyName = "test")]
        public bool? Test;

        public static Parcel createForShipment(double length, double width, double height, String distance_unit,
                                               double weight, string massUnit)
        {
            Parcel p = new Parcel();
            p.Length = length;
            p.Width = width;
            p.Height = height;
            p.DistanceUnit = distance_unit;
            p.Weight = weight;
            p.MassUnit = massUnit;
            return p;

        }
    }
}
