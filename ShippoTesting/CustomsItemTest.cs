using NUnit.Framework;
using System;
using System.Collections;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class CustomsItemTest : ShippoTest {

        [Test]
        public void TestValidCreate()
        {
            Hashtable parameters = getDefaultParameters();
            CustomsItem testObject = CustomsItemTest.getDefaultObject();
            Assert.AreEqual("VALID", testObject.ObjectState);
            Assert.AreEqual(parameters["description"], testObject.Description);
            Assert.AreEqual(int.Parse((string) parameters["quantity"]), testObject.Quantity);
            Assert.AreEqual(parameters["net_weight"], testObject.NetWeight);
            Assert.AreEqual(parameters["mass_unit"], testObject.MassUnit);
            Assert.AreEqual(parameters["value_amount"], testObject.ValueAmount);
            Assert.AreEqual(parameters["value_currency"], testObject.ValueCurrency);
            Assert.AreEqual(parameters["tariff_number"], testObject.TariffNumber);
            Assert.AreEqual(parameters["origin_country"], testObject.OriginCountry);
            Assert.AreEqual(parameters["sku_code"], testObject.SkuCode);
            Assert.AreEqual(parameters["eccn_ear99"], testObject.EccnEar99);
            Assert.AreEqual(parameters["metadata"], testObject.Metadata);
        }

        [Test]
        public void testValidRetrieve()
        {
            CustomsItem testObject = CustomsItemTest.getDefaultObject();
            CustomsItem retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsItem((string) testObject.ObjectId);
            Assert.AreEqual(testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test]
        public void testListAll()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", "1");
            parameters.Add("page", "1");

            var parcels = apiResource.AllCustomsItems(parameters);
            Assert.AreNotEqual(0, parcels.Data.Count);
        }

        public static Hashtable getDefaultParameters()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("description", "T-Shirt");
            parameters.Add("quantity", "2");
            parameters.Add("net_weight", "400");
            parameters.Add("mass_unit", "g");
            parameters.Add("value_amount", "20");
            parameters.Add("value_currency", "USD");
            parameters.Add("tariff_number", "");
            parameters.Add("origin_country", "US");
            parameters.Add("sku_code", "AB123");
            parameters.Add("eccn_ear99", "3A001");
            parameters.Add("metadata", "Order ID #123123");
            return parameters;
        }

        public static CustomsItem getDefaultObject()
        {
            return getAPIResource().CreateCustomsItem(getDefaultParameters());
        }
    }
}

