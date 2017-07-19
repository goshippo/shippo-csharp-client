using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject(MemberSerialization.OptIn)]
    public class Address : ShippoId {
        [JsonProperty(PropertyName = "is_complete")]
        public object IsComplete { get; set; }

        [JsonProperty(PropertyName = "object_created")]
        public object ObjectCreated { get; set; }

        [JsonProperty(PropertyName = "object_updated")]
        public object ObjectUpdated { get; set; }

        [JsonProperty(PropertyName = "object_owner")]
        public object ObjectOwner { get; set; }

        [JsonProperty(PropertyName = "name")]
        public object Name { get; set; }

        [JsonProperty(PropertyName = "company")]
        public object Company { get; set; }

        [JsonProperty(PropertyName = "street1")]
        public object Street1 { get; set; }

        [JsonProperty(PropertyName = "street_no")]
        public object StreetNo { get; set; }

        [JsonProperty(PropertyName = "street2")]
        public object Street2 { get; set; }

        [JsonProperty(PropertyName = "street3")]
        public string Street3;

        [JsonProperty(PropertyName = "city")]
        public object City { get; set; }

        [JsonProperty(PropertyName = "state")]
        public object State { get; set; }

        [JsonProperty(PropertyName = "zip")]
        public object Zip { get; set; }

        [JsonProperty(PropertyName = "country")]
        public object Country { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public object Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public object Email { get; set; }

        [JsonProperty(PropertyName = "is_residential")]
        public object IsResidential { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public object IP { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public string Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public string Longitude { get; set; }

        [JsonProperty(PropertyName = "validate")]
        public bool? Validate;

        [JsonProperty(PropertyName = "metadata")]
        public object Metadata { get; set; }

        [JsonProperty(PropertyName = "test")]
        public bool? Test;

        [JsonProperty(PropertyName = "validation_results")]
        public ValidationResults ValidationResults;

        public static Address createForPurchase(String name, String street1,
                                                String street2, String city, String state, String zip,
                                                String country, String phone, String email)
        {
            Address a = new Address();
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
}
