using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

using Shippo;

namespace ShippoTesting
{
    [TestFixture ()]
    public class BatchTest : ShippoTest
    {
        [Test ()]
        public void TestValidCreate ()
        {
            Batch testBatch = BatchTest.getDefaultObject ();
            Assert.AreEqual ("VALIDATING", testBatch.ObjectStatus);
        }

        public static Batch getDefaultObject ()
        {
            // Grab USPS carrier account to get the correct object ID for further testing.
            // This should be changed to be more generic in future versions of this test. In
            // otherwise remove the depedence on a USPS carrier account to exist.
            ShippoCollection<CarrierAccount> carrierAccounts = getAPIResource ().AllCarrierAccount ();
            string defaultCarrierAccount = "";
            foreach (CarrierAccount account in carrierAccounts) {
                if (account.Carrier.ToString() == "usps")
                    defaultCarrierAccount = account.ObjectId;
            }

            Hashtable parameters = new Hashtable ();
            parameters.Add ("default_carrier_account", defaultCarrierAccount);
            parameters.Add ("default_servicelevel_token", "usps_priority");
            parameters.Add ("label_filetype", "PDF_4x6");
            parameters.Add ("metadata", "BATCH #170");
            parameters.Add ("servicelevel_token", "fedex_2_day");

            Hashtable batchShipment = new Hashtable ();
            batchShipment.Add ("object_purpose", "PURCHASE");

            Hashtable addressFrom = new Hashtable ();
            addressFrom.Add ("object_purpose", "PURCHASE");
            addressFrom.Add ("name", "Mr. Hippo");
            addressFrom.Add ("street1", "965 Mission St");
            addressFrom.Add ("street2", "Ste 201");
            addressFrom.Add ("city", "San Francisco");
            addressFrom.Add ("state", "CA");
            addressFrom.Add ("zip", "94103");
            addressFrom.Add ("country", "US");
            addressFrom.Add ("phone", "4151234567");
            addressFrom.Add ("email", "mrhippo@goshippo.com");

            Hashtable addressTo = new Hashtable ();
            addressTo.Add ("object_purpose", "PURCHASE");
            addressTo.Add ("name", "Mrs. Hippo");
            addressTo.Add ("company", "");
            addressTo.Add ("street1", "Broadway 1");
            addressTo.Add ("street2", "");
            addressTo.Add ("city", "New York");
            addressTo.Add ("state", "NY");
            addressTo.Add ("zip", "10007");
            addressTo.Add ("country", "US");
            addressTo.Add ("phone", "4151234567");
            addressTo.Add ("email", "mrshippo@goshippo.com");

            Hashtable parcel = new Hashtable ();
            parcel.Add ("length", "5");
            parcel.Add ("width", "5");
            parcel.Add ("height", "5");
            parcel.Add ("distance_unit", "in");
            parcel.Add ("weight", "2");
            parcel.Add ("mass_unit", "oz");

            batchShipment.Add ("address_from", addressFrom);
            batchShipment.Add ("address_to", addressTo);
            batchShipment.Add ("parcel", parcel);

            Hashtable batchShipments = new Hashtable ();
            batchShipments.Add ("shipment", batchShipment);
            parameters.Add ("batch_shipments", new List<Hashtable> ());
            (parameters ["batch_shipments"] as List<Hashtable>).Add (batchShipments);

            return getAPIResource ().CreateBatch (parameters);
        }
    }
}
