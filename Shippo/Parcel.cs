using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Parcel : ShippoId
    {
        [JsonProperty(PropertyName = "object_state")]
        public string ObjectState { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public DateTime ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public DateTime ObjectUpdaed { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public string ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "length")]
        public decimal Length { get; set; }

        [JsonProperty(PropertyName = "width")]
        public decimal Width { get; set; }

        [JsonProperty(PropertyName = "height")]
        public decimal Height { get; set; }

        [JsonProperty(PropertyName = "distance_unit")]
        public string DistanceUnit { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public decimal Weight { get; set; }

        [JsonProperty(PropertyName = "mass_unit")]
        public string MassUnit { get; set; }

        [JsonProperty(PropertyName = "template")]
        public string Template;

        [JsonProperty(PropertyName = "metadata")]
        public string Metadata { get; set; }

        [JsonProperty(PropertyName = "extra")]
        public object Extra;

        [JsonProperty(PropertyName = "test")]
        public bool? Test;

        public static Parcel createForShipment(double length, double width, double height, String distance_unit,
                                               double weight, string massUnit)
        {
            Parcel p = new Parcel();
            p.Length = Convert.ToDecimal(length);
            p.Width = Convert.ToDecimal(width);
            p.Height = Convert.ToDecimal(height);
            p.DistanceUnit = distance_unit;
            p.Weight = Convert.ToDecimal(weight);
            p.MassUnit = massUnit;
            return p;

        }
    }
}
