using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Address : ShippoId {
        [JsonProperty (PropertyName = "object_state")]
        public string ObjectState;

        [JsonProperty (PropertyName = "object_purpose")]
        public string ObjectPurpose;

        [JsonProperty (PropertyName = "object_source")]
        public string ObjectSource;

        [JsonProperty (PropertyName = "object_created")]
        public DateTime? ObjectCreated;

        [JsonProperty (PropertyName = "object_updated")]
        public DateTime? ObjectUpdated;

        [JsonProperty (PropertyName = "object_owner")]
        public string ObjectOwner;

        [JsonProperty (PropertyName = "name")]
        public string Name;

        [JsonProperty (PropertyName = "company")]
        public string Company;

        [JsonProperty (PropertyName = "street1")]
        public string Street1;

        [JsonProperty (PropertyName = "street_no")]
        public string StreetNo;

        [JsonProperty (PropertyName = "street2")]
        public string Street2;

        [JsonProperty (PropertyName = "street3")]
        public string Street3;

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

        [JsonProperty (PropertyName = "is_residential")]
        public bool? IsResidential;

        [JsonProperty (PropertyName = "validate")]
        public bool? Validate;

        [JsonProperty (PropertyName = "metadata")]
        public string Metadata;

        [JsonProperty (PropertyName = "test")]
        public bool Test;

        [JsonProperty (PropertyName = "messages")]
        public List<string> Messages;

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
}
