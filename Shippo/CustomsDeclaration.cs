using System;
using Newtonsoft.Json;

namespace Shippo {

    [JsonObject(MemberSerialization.OptIn)]
    public class InvoicedCharges : ShippoId
    {
        [JsonProperty(PropertyName = "currency")]
        public object Currency { get; set; }

        [JsonProperty(PropertyName = "total_shipping")]
        public object TotalShipping { get; set; }

        [JsonProperty(PropertyName = "total_taxes")]
        public object TotalTaxes { get; set; }

        [JsonProperty(PropertyName = "total_duties")]
        public object TotalDuties { get; set; }

        [JsonProperty(PropertyName = "other_fees")]
        public object OtherFees { get; set; }
    }

    [JsonObject(MemberSerialization.OptIn)]
    public class ExporterIdentification : ShippoId
    {
        [JsonProperty(PropertyName = "eori_number")]
        public object EoriNumber { get; set; }
    }

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

        [JsonProperty (PropertyName = "address_importer")]
        public object AddressImporter { get; set; }

        [JsonProperty(PropertyName = "disclaimer")]
        public object Discliamer { get; set; }

        [JsonProperty(PropertyName = "incoterm")]
        public object Incoterm { get; set; }

        [JsonProperty(PropertyName = "items")]
        public object Items { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(PropertyName = "b13a_filing_option")]
        public object B13aFilingOption { get; set; }

        [JsonProperty(PropertyName = "b13a_number")]
        public object B13aNumber { get; set; }

        [JsonProperty(PropertyName = "invoiced_charges")]
        public InvoicedCharges InvoicedCharges { get; set; }

        [JsonProperty(PropertyName = "exporter_identification")]
        public ExporterIdentification ExporterIdentification { get; set; }
    }
}

