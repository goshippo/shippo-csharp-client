using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject (MemberSerialization.OptIn)]
    public class TrackingStatus : ShippoId
    {
        [JsonProperty (PropertyName = "object_created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "object_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ObjectUpdated;

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
            return string.Format ("[TrackingStatus: ObjectCreated={0}, ObjectUpdated={1}, Status={2}, StatusDetails={3}," +
                                  "StatusDate={4}, location={5}]", ObjectCreated, ObjectUpdated, Status.ToString (),
                                  StatusDetails, StatusDate, Location);
        }
    }
}
