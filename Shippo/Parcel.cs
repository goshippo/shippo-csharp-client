using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class Parcel : ShippoId
    {
        [JsonProperty (PropertyName = "object_state", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectState { get; set; }

        [JsonProperty (PropertyName = "object_created", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectUpdaed { get; set; }

        [JsonProperty (PropertyName = "object_owner", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "length", NullValueHandling = NullValueHandling.Ignore)]
        public object Length { get; set; }

        [JsonProperty (PropertyName = "width", NullValueHandling = NullValueHandling.Ignore)]
        public object Width { get; set; }

        [JsonProperty (PropertyName = "height", NullValueHandling = NullValueHandling.Ignore)]
        public object Height { get; set; }

        [JsonProperty (PropertyName = "distance_unit", NullValueHandling = NullValueHandling.Ignore)]
        public object DistanceUnit { get; set; }

        [JsonProperty (PropertyName = "weight", NullValueHandling = NullValueHandling.Ignore)]
        public object Weight { get; set; }

        [JsonProperty (PropertyName = "mass_unit", NullValueHandling = NullValueHandling.Ignore)]
        public object MassUnit { get; set; }

        [JsonProperty (PropertyName = "template", NullValueHandling = NullValueHandling.Ignore)]
        public string Template;

        [JsonProperty (PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        [JsonProperty (PropertyName = "extra", NullValueHandling = NullValueHandling.Ignore)]
        public object Extra;

        [JsonProperty (PropertyName = "test", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Test;

        public static Parcel createForShipment (double length, double width, double height, String distance_unit,
                                                    double weight, string massUnit)
        {
            Parcel p = new Parcel ();
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