using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class TrackingHistory : ShippoId
    {
        [JsonProperty (PropertyName = "object_created")]
        public DateTime? ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "status")]
        public string Status { get; set; }

        [JsonProperty (PropertyName = "status_details")]
        public string StatusDetails { get; set; }

        [JsonProperty (PropertyName = "status_date")]
        public DateTime? StatusDate { get; set; }

        [JsonProperty (PropertyName = "location")]
        public ShortAddress location { get; set; }

        public override string ToString ()
        {
            return string.Format ("[TrackingHistory: ObjectCreated={0}, Status={1}, StatusDetails={2}, StatusDate={3}," +
                                  "location={4}]", ObjectCreated, Status, StatusDetails, StatusDate, location);
        }
    }
}
