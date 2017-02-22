using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Shippo {
    [JsonObject (MemberSerialization.OptIn)]
    public class Address : ShippoId {
        [JsonProperty (PropertyName = "object_state", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectState { get; set; }

        [JsonProperty (PropertyName = "object_purpose", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectPurpose { get; set; }

        [JsonProperty (PropertyName = "object_source", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectSource { get; set; }

        [JsonProperty (PropertyName = "object_created", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectCreated { get; set; }

        [JsonProperty (PropertyName = "object_updated", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectUpdated { get; set; }

        [JsonProperty (PropertyName = "object_owner", NullValueHandling = NullValueHandling.Ignore)]
        public object ObjectOwner { get; set; }

        [JsonProperty (PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        public object Name { get; set; }

        [JsonProperty (PropertyName = "company", NullValueHandling = NullValueHandling.Ignore)]
        public object Company { get; set; }

        [JsonProperty (PropertyName = "street1", NullValueHandling = NullValueHandling.Ignore)]
        public object Street1 { get; set; }

        [JsonProperty (PropertyName = "street_no", NullValueHandling = NullValueHandling.Ignore)]
        public object StreetNo { get; set; }

        [JsonProperty (PropertyName = "street2", NullValueHandling = NullValueHandling.Ignore)]
        public object Street2 { get; set; }

        [JsonProperty (PropertyName = "street3", NullValueHandling = NullValueHandling.Ignore)]
        public string Street3;

        [JsonProperty (PropertyName = "city", NullValueHandling = NullValueHandling.Ignore)]
        public object City { get; set; }

        [JsonProperty (PropertyName = "state", NullValueHandling = NullValueHandling.Ignore)]
        public object State { get; set; }

        [JsonProperty (PropertyName = "zip", NullValueHandling = NullValueHandling.Ignore)]
        public object Zip { get; set; }

        [JsonProperty (PropertyName = "country", NullValueHandling = NullValueHandling.Ignore)]
        public object Country { get; set; }

        [JsonProperty (PropertyName = "phone", NullValueHandling = NullValueHandling.Ignore)]
        public object Phone { get; set; }

        [JsonProperty (PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public object Email { get; set; }

        [JsonProperty (PropertyName = "is_residential", NullValueHandling = NullValueHandling.Ignore)]
        public object IsResidential { get; set; }

        [JsonProperty (PropertyName = "ip", NullValueHandling = NullValueHandling.Ignore)]
        public object IP { get; set; }

        [JsonProperty (PropertyName = "validate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Validate;

        [JsonProperty (PropertyName = "metadata", NullValueHandling = NullValueHandling.Ignore)]
        public object Metadata { get; set; }

        [JsonProperty (PropertyName = "test", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Test;

        [JsonProperty (PropertyName = "messages", NullValueHandling = NullValueHandling.Ignore)]
        public object Messages;

        public static Address createForPurchase (ShippoEnums.ObjectPurposes purpose, String name, String street1,
                                                     String street2, String city, String state, String zip,
                                                     String country, String phone, String email)
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
