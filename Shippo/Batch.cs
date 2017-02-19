using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Batch : ShippoId {
        public enum ObjectStatuses { VALIDATING, VALID, INVALID, PURCHASING, PURCHASED }

        [JsonProperty (PropertyName = "object_status")]
        public ObjectStatuses ObjectStatus;

        [JsonProperty (PropertyName = "object_created")]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "object_updated")]
        public DateTime? ObjectUpdated;

        [JsonProperty (PropertyName = "object_owner")]
        public string ObjectOwner;

        [JsonProperty (PropertyName = "default_carrier_account")]
        public string DefaultCarrierAccount;

        [JsonProperty (PropertyName = "default_servicelevel_token")]
        public string DefaultServicelevelToken;

        [JsonProperty (PropertyName = "label_filetype")]
        public string LabelFiletype;

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata;

        [JsonProperty (PropertyName = "batch_shipments")]
        public BatchShipments BatchShipments;

        [JsonProperty (PropertyName = "label_url")]
        public List<String> LabelUrl;

        [JsonProperty (PropertyName = "object_results")]
        public ObjectResults ObjectResults;

        public class Address
        {
            [JsonProperty (PropertyName = "object_purpose")]
            public string ObjectPurpose;

            [JsonProperty (PropertyName = "name")]
            public string Name;

            [JsonProperty (PropertyName = "company")]
            public string Company;

            [JsonProperty (PropertyName = "street1")]
            public string Street1;

            [JsonProperty (PropertyName = "street2")]
            public string Street2;

            [JsonProperty (PropertyName = "city")]
            public string City;

            [JsonProperty (PropertyName = "state")]
            public string State;

            [JsonProperty (PropertyName = "zip")]
            public string Zip;

            [JsonProperty (PropertyName = "country")]
            public string Country;

            [JsonProperty (PropertyName = "phone")]
            public string Phone;

            [JsonProperty (PropertyName = "email")]
            public string Email;

            public static Address createForPurchase (String purpose, String name, String street1, String street2, String city,
                                                     String state, String zip, String country, String phone, String email)
            {
                Address a = new Address ();
                a.ObjectPurpose = purpose;
                a.Name = name;
                a.Street1 = street1;
                a.Street2 = street2;
                a.City = city;
                a.State = state;
                a.Zip = zip;
                a.Country = country;
                a.Phone = phone;
                a.Email = email;
                return a;
            }
        }

        public class BatchShipment
        {
            [JsonProperty (PropertyName = "carrier_account")]
            public string CarrierAccount;

            [JsonProperty (PropertyName = "servicelevel_token")]
            public string ServicelevelToken;

            [JsonProperty (PropertyName = "shipment")]
            public Shipment Shipment;

            public static BatchShipment createForBatchShipments (String carrierAccount, string servicelevelToken, Shipment shipment)
            {
                BatchShipment bs = new BatchShipment ();
                bs.CarrierAccount = carrierAccount;
                bs.ServicelevelToken = servicelevelToken;
                bs.Shipment = shipment;
                return bs;
            }
        }

        public class Shipment
        {
            [JsonProperty (PropertyName = "object_purpose")]
            public string ObjectPurpose;

            [JsonProperty (PropertyName = "address_from")]
            public Address AddressFrom;

            [JsonProperty (PropertyName = "address_to")]
            public Address AddressTo;

            [JsonProperty (PropertyName = "parcel")]
            public Parcel Parcel;

            public static Shipment createForBatch (String purpose, Address addressFrom, Address addressTo, Parcel parcel)
            {
                Shipment s = new Shipment ();
                s.ObjectPurpose = purpose;
                s.AddressFrom = addressFrom;
                s.AddressTo = addressTo;
                s.Parcel = parcel;
                return s;
            }
        }

        public class Parcel
        {
            [JsonProperty (PropertyName = "length")]
            public double Length;

            [JsonProperty (PropertyName = "width")]
            public double Width;

            [JsonProperty (PropertyName = "height")]
            public double Height;

            [JsonProperty (PropertyName = "distance_unit")]
            public string DistanceUnit;

            [JsonProperty (PropertyName = "weight")]
            public double Weight;

            [JsonProperty (PropertyName = "mass_unit")]
            public string MassUnit;

            public static Parcel createForShipment (double length, double width, double height, String distance_unit,
                                                    double weight, string massUnit)
            {
                Parcel p = new Parcel ();
                p.Length = length;
                p.Width = width;
                p.Height = height;
                p.DistanceUnit = distance_unit;
                p.Weight = weight;
                p.MassUnit = massUnit;
                return p;

            }
        }

        public override string ToString ()
        {
            return string.Format ("[Batch: ObjectStatus={0}, ObjectCreated={1}, ObjectUpdated={2}, ObjectOwner={3}, " +
                                  "DefaultCarrierAccount={4}, DefaultServicelevelToken={5}, LabelFiletype={6}, Metadata={7}, " +
                                  "BatchShipments={8}, LabelUrl={9}, ObjectResults={10}]", ObjectStatus, ObjectCreated,
                                  ObjectUpdated, ObjectOwner, DefaultCarrierAccount, DefaultServicelevelToken,
                                  LabelFiletype, Metadata, BatchShipments, LabelUrl, ObjectResults);
        }
    }
}
