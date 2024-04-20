﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

using Shippo;


namespace ShippoTesting
{
    [TestFixture]
    public class BatchTest : ShippoTest
    {
        void HandleFunc() {}

        [Test]
        public void TestValidCreate()
        {
            Batch testBatch = getDefaultObject();
            Assert.Equals(ShippoEnums.Statuses.VALIDATING, testBatch.Status);
        }

        [Test]
        public void TestInvalidCreate()
        {
            Assert.That(() => getAPIResource().CreateBatch("invalid_carrier_account", "invalid_servicelevel_token", ShippoEnums.LabelFiletypes.NONE, "", new List<BatchShipment>()),
                        Throws.TypeOf<ShippoException>());
        }

        [Test]
        public void TestValidRetrieve()
        {
            Batch batch = getDefaultObject();
            Batch retrieve = getAPIResource().RetrieveBatch(batch.ObjectId, 0, ShippoEnums.ObjectResults.none);
            Assert.Equals(batch.ObjectId, retrieve.ObjectId);
            Assert.Equals(batch.ObjectCreated, retrieve.ObjectCreated);
        }

        [Test]
        public void TestInvalidRetrieve()
        {
            Assert.That(() => getAPIResource().RetrieveBatch("INVALID_ID", 0, ShippoEnums.ObjectResults.none),
                        Throws.TypeOf<ShippoException>());
        }
/*
        [Test]
        public void TestValidAddShipmentToBatch()
        {
            setLive(true);//Temporary work around for batch request bug with test token
            Batch batch = getDefaultObject();
            Assert.Equals(batch.Status, ShippoEnums.Statuses.VALIDATING);

            List<String> shipmentIds = new List<String>();
            Shipment shipment = ShipmentTest.getDefaultObject();
            shipmentIds.Add(shipment.ObjectId);

            Batch retrieve = getValidBatch(batch.ObjectId);
            Batch newBatch = getAPIResource().AddShipmentsToBatch(retrieve.ObjectId, shipmentIds);
            setLive(false);
            Assert.Equals(retrieve.BatchShipments.Count + shipmentIds.Count, newBatch.BatchShipments.Count);
        }
*/
        [Test]
        public void TestInvalidAddShipmentToBatch()
        {
            List<String> shipmentIds = new List<String>();
            shipmentIds.Add("123");
			Assert.That(() => getAPIResource().AddShipmentsToBatch("INVALID_ID", shipmentIds),
                         Throws.TypeOf<ShippoException>());
        }
/*
        [Test]
        public void TestValidRemoveShipmentsFromBatch()
        {
            setLive(true);
            Batch batch = getDefaultObject();
            Assert.Equals(batch.Status, ShippoEnums.Statuses.VALIDATING);

            List<String> shipmentIds = new List<String>();
            Shipment shipment = ShipmentTest.getDefaultObject();
            shipmentIds.Add(shipment.ObjectId);

            Batch retrieve = getValidBatch(batch.ObjectId);
            Batch addBatch = getAPIResource().AddShipmentsToBatch(retrieve.ObjectId, shipmentIds);

            string removeId = addBatch.BatchShipments.Results[0].ObjectId;
            List<String> shipmentsToRemove = new List<String>();
            shipmentsToRemove.Add(removeId);

            Batch removeBatch = getAPIResource().RemoveShipmentsFromBatch(batch.ObjectId, shipmentsToRemove);
            setLive(false);
            Assert.Equals(retrieve.BatchShipments.Count, removeBatch.BatchShipments.Count);
        }
*/
        [Test]
        public void TestInvalidRemoveShipmentsFromBatch()
        {
            List<String> shipments = new List<String>();
            shipments.Add("123");
            Assert.That(() => getAPIResource().RemoveShipmentsFromBatch("INVALID_ID", shipments),
                        Throws.TypeOf<ShippoException>());
        }

/*        [Test]
        public void TestValidPurchase()
        {
            Batch batch = getDefaultObject();
            Batch retrieve = getValidBatch(batch.ObjectId);
            Batch purchase = getAPIResource().PurchaseBatch(retrieve.ObjectId);
            Assert.Equals(ShippoEnums.Statuses.PURCHASING, purchase.Status);
        }
*/
        [Test]
        public void TestInvalidPurchase()
        {
            Assert.That(() => getAPIResource().PurchaseBatch("INVALID_ID"),
                        Throws.TypeOf<ShippoException>());
        }

        /**
         * Retries up to 10 times to retrieve a batch that has been recently
         * created until the newly created batch is 'VALID' and not 'VALIDATING'.
         */
        public Batch getValidBatch(String id)
        {
            Batch batch;
            int retries = 10;
            for (; retries > 0; retries--) {
                batch = getAPIResource().RetrieveBatch(id, 0, ShippoEnums.ObjectResults.none);
                if (batch.Status != ShippoEnums.Statuses.VALIDATING)
                    return batch;
                System.Threading.Thread.Sleep(1000);
            }
            throw new ShippoException("Could not retrieve valid Batch", new TimeoutException());
        }

        public static Batch getDefaultObject()
        {
            // Grab USPS carrier account to get the correct object ID for further testing.
            // This should be changed to be more generic in future versions of this test. In
            // other words, remove the depedence on a USPS carrier account to exist.
            ShippoCollection<CarrierAccount> carrierAccounts = getAPIResource().AllCarrierAccount();
            string defaultCarrierAccount = "";
            foreach (CarrierAccount account in carrierAccounts) {
                if (account.Carrier.ToString() == "usps")
                    defaultCarrierAccount = account.ObjectId;
            }

            Address addressFrom = Address.createForPurchase("Mr. Hippo", "965 Mission St.", "Ste 201", "SF",
                                                            "CA", "94103", "US", "4151234567", "ship@gmail.com");
            Address addressTo = Address.createForPurchase("Mrs. Hippo", "965 Missions St.", "Ste 202", "SF",
                                                          "CA", "94103", "US", "4151234568", "msship@gmail.com");
            Parcel[] parcels = {Parcel.createForShipment(5, 5, 5, "in", 2, "oz")};
            Shipment shipment = Shipment.createForBatch(addressFrom, addressTo, parcels);
            BatchShipment batchShipment = BatchShipment.createForBatchShipments(defaultCarrierAccount, "usps_priority", shipment);

            List<BatchShipment> batchShipments = new List<BatchShipment>();
            batchShipments.Add(batchShipment);

            Batch batch = getAPIResource().CreateBatch(defaultCarrierAccount, "usps_priority", ShippoEnums.LabelFiletypes.PDF_4x6,
                                                       "BATCH #170", batchShipments);
            Assert.Equals(ShippoEnums.Statuses.VALIDATING, batch.Status);
            return batch;
        }
    }
}
