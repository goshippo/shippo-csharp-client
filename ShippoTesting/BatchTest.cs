using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Shippo;

namespace ShippoTesting
{
    [TestFixture ()]
    public class BatchTest : ShippoTest
    {
        [Test ()]
        public void TestValidCreate ()
        {
            Batch testBatch = getDefaultObject ();
            Assert.AreEqual ("VALIDATING", testBatch.ObjectStatus);
        }

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidCreate ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("default_carrier_account", "invalid_carrier_account");
            parameters.Add ("default_servicelevel_token", "invalid_servicelevel_token");
            getAPIResource ().CreateBatch (parameters);
        }

        [Test ()]
        public void TestValidRetrieve ()
        {
            Batch batch = getDefaultObject ();
            Batch batchRetrieved = getAPIResource ().RetrieveBatch (batch.ObjectId);
            Assert.AreEqual (batch.ObjectId, batchRetrieved.ObjectId);
            Assert.AreEqual (batch.ObjectCreated, batchRetrieved.ObjectCreated);
        }

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidRetrieve ()
        {
            getAPIResource ().RetrieveBatch ("INVALID_ID");
        }

        [Test ()]
        public void TestValidAddShipmentToBatch ()
        {
            Batch batch = getDefaultObject ();
            Assert.AreEqual (batch.ObjectStatus, "VALIDATING");

            List<Hashtable> shipments = new List<Hashtable> ();
            Hashtable shipmentTable = new Hashtable ();
            Shipment shipment = ShipmentTest.getDefaultObject ();
            shipmentTable.Add ("shipment", shipment.ObjectId);
            shipments.Add (shipmentTable);

            Batch retrieve = getValidBatch (batch.ObjectId);
            Batch newBatch = getAPIResource ().AddShipmentsToBatch (retrieve.ObjectId, shipments);

            Hashtable batchTable = JsonConvert.DeserializeObject<Hashtable> (retrieve.BatchShipments.ToString ());
            Hashtable newBatchTable = JsonConvert.DeserializeObject<Hashtable> (newBatch.BatchShipments.ToString ());
            JArray batchResults = batchTable ["results"] as JArray;
            JArray newBatchResults = newBatchTable ["results"] as JArray;

            Assert.AreEqual (batchResults.Count + shipments.Count, newBatchResults.Count);
        }

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidAddShipmentToBatch ()
        {
            List<Hashtable> shipments = new List<Hashtable> ();
            Hashtable shipmentTable = new Hashtable ();
            shipmentTable.Add ("shipment", "123");
            shipments.Add (shipmentTable);
            getAPIResource ().AddShipmentsToBatch ("INVALID_ID", shipments);
        }

        [Test ()]
        public void TestValidRemoveShipmentsFromBatch ()
        {
            Batch batch = getDefaultObject ();
            Assert.AreEqual (batch.ObjectStatus, "VALIDATING");

            List<Hashtable> shipments = new List<Hashtable> ();
            Hashtable shipmentTable = new Hashtable ();
            Shipment shipment = ShipmentTest.getDefaultObject ();
            shipmentTable.Add ("shipment", shipment.ObjectId);
            shipments.Add (shipmentTable);

            Batch retrieve = getValidBatch (batch.ObjectId);
            Hashtable batchTable = JsonConvert.DeserializeObject<Hashtable> (retrieve.BatchShipments.ToString ());
            JArray batchResults = batchTable ["results"] as JArray;

            Batch addBatch = getAPIResource ().AddShipmentsToBatch (retrieve.ObjectId, shipments);
            Hashtable addBatchTable = JsonConvert.DeserializeObject<Hashtable> (addBatch.BatchShipments.ToString ());
            JArray addBatchResults = addBatchTable ["results"] as JArray;
            Assert.AreEqual (batchResults.Count + shipments.Count, addBatchResults.Count);

            string removeId = addBatchResults [0] ["object_id"].ToString ();
            List<String> shipmentsToRemove = new List<String> ();
            shipmentsToRemove.Add (removeId);

            Batch removeBatch = getAPIResource ().RemoveShipmentsFromBatch (batch.ObjectId, shipmentsToRemove);
            Hashtable removeBatchTable = JsonConvert.DeserializeObject<Hashtable> (removeBatch.BatchShipments.ToString ());
            JArray removeBatchResults = removeBatchTable ["results"] as JArray;
            Assert.AreEqual (batchResults.Count, removeBatchResults.Count);
        }

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidRemoveShipmentsFromBatch ()
        {
            List<String> shipments = new List<String> ();
            shipments.Add ("123");
            getAPIResource ().RemoveShipmentsFromBatch ("INVALID_ID", shipments);
        }

        [Test ()]
        public void TestValidPurchase ()
        {
            Batch batch = getDefaultObject ();
            Batch retrieve = getValidBatch (batch.ObjectId);
            Batch purchase = getAPIResource ().PurchaseBatch (retrieve.ObjectId);
            Assert.AreEqual ("PURCHASING", purchase.ObjectStatus);
        }

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidPurchase ()
        {
            getAPIResource ().PurchaseBatch ("INVALID_ID");
        }

        /**
         * Retries up to 10 times to retrieve a batch that has been recently 
         * created until the newly created batch is 'VALID' and not 'VALIDATING'.
         */
        public Batch getValidBatch (String id)
        {
            Batch batch;
            int retries = 10;
            for (; retries > 0; retries--) {
                batch = getAPIResource ().RetrieveBatch (id);
                if (batch.ObjectStatus.ToString () == "VALID")
                    return batch;
                System.Threading.Thread.Sleep (1000);
            }
            throw new ShippoException ("Could not retrieve valid Batch", new TimeoutException());
        }

        public static Batch getDefaultObject ()
        {
            // Grab USPS carrier account to get the correct object ID for further testing.
            // This should be changed to be more generic in future versions of this test. In
            // other words, remove the depedence on a USPS carrier account to exist.
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

            Hashtable shipment = new Hashtable ();
            shipment.Add ("object_purpose", "PURCHASE");

            Hashtable addressFrom = new Hashtable ();
            addressFrom.Add ("object_purpose", "PURCHASE");
            addressFrom.Add ("name", "Mr. Hippo");
            addressFrom.Add ("company", "");
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
            parcel.Add ("template", "");
            parcel.Add ("metadata", "Parcel 123");

            shipment.Add ("address_from", addressFrom);
            shipment.Add ("address_to", addressTo);
            shipment.Add ("parcel", parcel);

            Hashtable batchShipment = new Hashtable ();
            batchShipment.Add ("shipment", shipment);
            parameters.Add ("batch_shipments", new List<Hashtable> ());
            (parameters ["batch_shipments"] as List<Hashtable>).Add (batchShipment);

            return getAPIResource ().CreateBatch (parameters);
        }
    }
}
