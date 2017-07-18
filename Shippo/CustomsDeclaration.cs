using System;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class CustomsDeclaration : ShippoId {
        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "object_state")]
        public object ObjectState { get; set; }

        [JsonProperty(PropertyName = "exporter_reference")]
        public object ExporterReference { get; set; }

        [JsonProperty(PropertyName = "importer_reference")]
        public object ImporterReference { get; set; }

        [JsonProperty(PropertyName = "contents_type")]
        public object ContentsType { get; set; }

        [JsonProperty(PropertyName = "contents_explanation")]
        public object ContentsExplanation { get; set; }

        [JsonProperty(PropertyName = "invoice")]
        public object Invoice { get; set; }

        [JsonProperty(PropertyName = "license")]
        public object License { get; set; }

        [JsonProperty(PropertyName = "certificate")]
        public object Certificate { get; set; }

        [JsonProperty(PropertyName = "notes")]
        public object Notes { get; set; }

        [JsonProperty(PropertyName = "eel_pfc")]
        public object EelPfc { get; set; }

        [JsonProperty(PropertyName = "aes_itn")]
        public object AesItn { get; set; }

        [JsonProperty(PropertyName = "non_delivery_option")]
        public object NonDeliveryOption { get; set; }

        [JsonProperty(PropertyName = "certify")]
        public object Certify { get; set; }

        [JsonProperty(PropertyName = "certify_signer")]
        public object CertifySigner { get; set; }

        [JsonProperty(PropertyName = "disclaimer")]
        public object Discliamer { get; set; }

        [JsonProperty(PropertyName = "incoterm")]
        public object Incoterm { get; set; }

        [JsonProperty(PropertyName = "items")]
        public object Items { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }
    }
}

