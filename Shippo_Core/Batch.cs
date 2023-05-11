using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Batch : ShippoId {
        [JsonProperty(PropertyName = "status")]
        public ShippoEnums.Statuses Status;

        [JsonProperty(PropertyName = "object_created")]
        public DateTime? ObjectCreated;

        [JsonProperty(PropertyName = "object_updated")]
        public DateTime? ObjectUpdated;

        [JsonProperty(PropertyName = "object_owner")]
        public string ObjectOwner;

        [JsonProperty(PropertyName = "default_carrier_account")]
        public string DefaultCarrierAccount;

        [JsonProperty(PropertyName = "default_servicelevel_token")]
        public string DefaultServicelevelToken;

        [JsonProperty(PropertyName = "label_filetype")]
        public ShippoEnums.LabelFiletypes LabelFiletype;

        [JsonProperty(PropertyName = "metadata")]
        public string Metadata;

        [JsonProperty(PropertyName = "batch_shipments")]
        public BatchShipments BatchShipments;

        [JsonProperty(PropertyName = "label_url")]
        public List<String> LabelUrl;

        [JsonProperty(PropertyName = "object_results")]
        public ObjectResults ObjectResults;

        public override string ToString()
        {
            return string.Format("[Batch: Status={0}, ObjectCreated={1}, ObjectUpdated={2}, ObjectOwner={3}, " +
                                 "DefaultCarrierAccount={4}, DefaultServicelevelToken={5}, LabelFiletype={6}, Metadata={7}, " +
                                 "BatchShipments={8}, LabelUrl={9}, ObjectResults={10}]", Status.ToString(), ObjectCreated,
                                 ObjectUpdated, ObjectOwner, DefaultCarrierAccount, DefaultServicelevelToken,
                                 LabelFiletype, Metadata, BatchShipments, LabelUrl, ObjectResults);
        }
    }
}
