using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class Parcel : ShippoId
    {
        [JsonProperty (PropertyName = "object_state")]
        public string ObjectState;

        [JsonProperty (PropertyName = "object_created")]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "object_updated")]
        public DateTime? ObjectUpdaed;

        [JsonProperty (PropertyName = "object_owner")]
        public string ObjectOwner;

        [JsonProperty (PropertyName = "length")]
        public double Length;

        [JsonProperty (PropertyName = "width")]
        public double Width;

        [JsonProperty (PropertyName = "height")]
        public double Height;

        [JsonProperty (PropertyName = "distance_unit")]
        public string DistanceUnit;

        [JsonProperty (PropertyName = "weight")]
        public double Weight;

        [JsonProperty (PropertyName = "mass_unit")]
        public string MassUnit;

        [JsonProperty (PropertyName = "template")]
        public string Template;

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata;

        [JsonProperty (PropertyName = "extra")]
        public object Extra;

        [JsonProperty (PropertyName = "test")]
        public bool Test;

        public static Parcel createForShipment (double length, double width, double height,String distance_unit,
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