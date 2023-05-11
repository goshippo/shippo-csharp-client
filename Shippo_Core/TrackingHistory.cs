using System;
using Newtonsoft.Json;

namespace Shippo
{
    [JsonObject(MemberSerialization.OptIn)]
    public class TrackingHistory : ShippoId
    {
        [JsonProperty(PropertyName = "object_created")]
        public DateTime? ObjectCreated;

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
            return string.Format("[TrackingHistory: ObjectCreated={0}, Status={1}, StatusDetails={2}, StatusDate={3}," +
                                 "location={4}]", ObjectCreated, Status.ToString(), StatusDetails, StatusDate, Location);
        }
    }
}
