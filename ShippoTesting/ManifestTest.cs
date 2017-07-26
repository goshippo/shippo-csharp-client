﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

using Shippo;


namespace ShippoTesting
{
    [TestFixture]
    public class ManifestTest : ShippoTest
    {

        [Test]
        public void TestInvalidCreate()
        {
			Assert.That(() => ManifestTest.getDefaultObject(), Throws.TypeOf<ShippoException>());
        }

        [Test]
        public void testValidRetrieve()
        {
            Manifest testObject = ManifestTest.getDefaultObject();
            Manifest retrievedObject;

            retrievedObject = apiResource.RetrieveManifest((string) testObject.ObjectId);
            Assert.AreEqual(testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test]
        public void testListAll()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", "1");
            parameters.Add("page", "1");

            var Manifests = apiResource.AllManifests(parameters);
            Assert.AreEqual(0, Manifests.Data.Count);
        }

        public static Manifest getDefaultObject()
        {
            Hashtable parameters0 = new Hashtable();
            Address addressFrom = AddressTest.getDefaultObject();
            Address addressTo = AddressTest.getDefaultObject_2();
            Parcel parcel = ParcelTest.getDefaultObject();
            parameters0.Add("address_from", addressFrom.ObjectId);
            parameters0.Add("address_to", addressTo.ObjectId);
            parameters0.Add("parcels", new String[]{ parcel.ObjectId});
            parameters0.Add("shipment_date", now);
            parameters0.Add("insurance_amount", "30");
            parameters0.Add("insurance_currency", "USD");
            parameters0.Add("extra", "{signature_confirmation: true}");
            parameters0.Add("customs_declaration", "");
            parameters0.Add("metadata", "Customer ID 123456");
            parameters0.Add("async", false);

            Shipment shipment = getAPIResource().CreateShipment(parameters0);
            Hashtable parameters1 = new Hashtable();
            parameters1.Add("id", shipment.ObjectId);
            parameters1.Add("currency_code", "USD");

            ShippoCollection<Rate> rateCollection = getAPIResource().GetShippingRatesSync(parameters1);
            List<Rate> rateList = rateCollection.Data;
            Rate[] rateArray = rateList.ToArray();

            parameters1.Add("rate", rateArray [0].ObjectId);
            parameters1.Add("metadata", "Customer ID 123456");

            Transaction transaction = getAPIResource().CreateTransactionSync(parameters1);

            Hashtable parameters2 = new Hashtable();
            parameters2.Add("provider", "USPS");
            parameters2.Add("shipment_date", now);
            parameters2.Add("address_from", addressFrom.ObjectId);
            List<String> transactions = new List<String>();
            transactions.Add(transaction.ObjectId);
            parameters2.Add("transactions", transactions);

            return getAPIResource().CreateManifest(parameters2);
        }
    }
}

