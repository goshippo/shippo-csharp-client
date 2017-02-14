using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class TrackingStatus : ShippoId
    {
        [JsonProperty (PropertyName = "object_created")]
        public DateTime? ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated")]
        public DateTime? ObjectUpdated { get; set; }

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
            return string.Format ("[TrackingStatus: ObjectCreated={0}, ObjectUpdated={1}, Status={2}, StatusDetails={3}," +
                                  "StatusDate={4}, location={5}]", ObjectCreated, ObjectUpdated, Status, StatusDetails,
                                  StatusDate, location);
        }
    }
}
