using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Batch : ShippoId {
        [JsonProperty (PropertyName = "object_status", NullValueHandling = NullValueHandling.Ignore)]
        public ShippoEnums.ObjectStatuses ObjectStatus;

        [JsonProperty (PropertyName = "object_created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "object_updated", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ObjectUpdated;

        [JsonProperty (PropertyName = "object_owner", NullValueHandling = NullValueHandling.Ignore)]
        public string ObjectOwner;

        [JsonProperty (PropertyName = "default_carrier_account", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultCarrierAccount;

        [JsonProperty (PropertyName = "default_servicelevel_token", NullValueHandling = NullValueHandling.Ignore)]
        public string DefaultServicelevelToken;

        [JsonProperty (PropertyName = "label_filetype", NullValueHandling = NullValueHandling.Ignore)]
        public ShippoEnums.LabelFiletypes LabelFiletype;

        [JsonProperty (PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public string Metadata;

        [JsonProperty (PropertyName = "batch_shipments", NullValueHandling = NullValueHandling.Ignore)]
        public BatchShipments BatchShipments;

        [JsonProperty (PropertyName = "label_url", NullValueHandling = NullValueHandling.Ignore)]
        public List<String> LabelUrl;

        [JsonProperty (PropertyName = "object_results", NullValueHandling = NullValueHandling.Ignore)]
        public ObjectResults ObjectResults;

        public override string ToString ()
        {
            return string.Format ("[Batch: ObjectStatus={0}, ObjectCreated={1}, ObjectUpdated={2}, ObjectOwner={3}, " +
                                  "DefaultCarrierAccount={4}, DefaultServicelevelToken={5}, LabelFiletype={6}, Metadata={7}, " +
                                  "BatchShipments={8}, LabelUrl={9}, ObjectResults={10}]", ObjectStatus.ToString(), ObjectCreated,
                                  ObjectUpdated, ObjectOwner, DefaultCarrierAccount, DefaultServicelevelToken,
                                  LabelFiletype, Metadata, BatchShipments, LabelUrl, ObjectResults);
        }
    }
}
