using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TrackingStatus : ShippoId
    {
        [JsonProperty(PropertyName = "object_created")]
        public DateTime? ObjectCreated;

        [JsonProperty(PropertyName = "object_updated")]
        public DateTime? ObjectUpdated;

        [JsonProperty(PropertyName = "status")]
        public ShippoEnums.TrackingStatus Status;

        [JsonProperty(PropertyName = "status_details")]
        public string StatusDetails;

        [JsonProperty(PropertyName = "status_date")]
        public DateTime? StatusDate;

        [JsonProperty(PropertyName = "location")]
        public ShortAddress Location;

        public override string ToString()
        {
            return string.Format("[TrackingStatus: ObjectCreated={0}, ObjectUpdated={1}, Status={2}, StatusDetails={3}," +
                                 "StatusDate={4}, location={5}]", ObjectCreated, ObjectUpdated, Status.ToString(),
                                 StatusDetails, StatusDate, Location);
        }
    }
}
