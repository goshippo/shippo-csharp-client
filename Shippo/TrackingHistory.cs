using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class TrackingHistory : ShippoId
    {
        [JsonProperty (PropertyName = "object_created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "status", NullValueHandling = NullValueHandling.Ignore)]
        public ShippoEnums.TrackingStatus Status;

        [JsonProperty (PropertyName = "status_details", NullValueHandling = NullValueHandling.Ignore)]
        public string StatusDetails;

        [JsonProperty (PropertyName = "status_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StatusDate;

        [JsonProperty (PropertyName = "location", NullValueHandling = NullValueHandling.Ignore)]
        public ShortAddress Location;

        public override string ToString ()
        {
            return string.Format ("[TrackingHistory: ObjectCreated={0}, Status={1}, StatusDetails={2}, StatusDate={3}," +
                                  "location={4}]", ObjectCreated, Status.ToString (), StatusDetails, StatusDate, Location);
        }
    }
}
