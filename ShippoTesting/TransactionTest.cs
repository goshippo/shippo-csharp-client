﻿using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class TransactionTest : ShippoTest {

        /* Intentionally commented; cannot be tested without proper billing credentials
        [Test]
        public void TestValidCreate()
        {
            Transaction testObject = TransactionTest.getDefaultObject();
            Assert.Equals("VALID", testObject.ObjectState);
        }

        [Test]
        public void testValidRetrieve()
        {
            Transaction testObject = TransactionTest.getDefaultObject();
            Transaction retrievedObject;

            retrievedObject = apiResource.RetrieveTransaction((string) testObject.ObjectId);
            Assert.Equals(testObject.ObjectId, retrievedObject.ObjectId);
        } */

        [Test]
        public void testListAll()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", "1");
            parameters.Add("page", "1");

            var parcels = apiResource.AllTransactions(parameters);
            Assert.That(parcels.Data.Count > 0);
        }

        public static Transaction getDefaultObject()
        {
            Hashtable parameters = new Hashtable();

            ShippoCollection<Rate> rateCollection = RateTest.getDefaultObject();
            List<Rate> rateList = rateCollection.Data;
            Rate[] rateArray = rateList.ToArray();

            parameters.Add("rate", rateArray [0].ObjectId);
            parameters.Add("metadata", "Customer ID 123456");

            return getAPIResource().CreateTransactionSync(parameters);
        }
    }
}

