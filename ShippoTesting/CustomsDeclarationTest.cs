using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

using Shippo;


namespace ShippoTesting
{
    [TestFixture]
    public class CustomsDeclarationTest : ShippoTest
    {

        [Test]
        public void TestValidCreate()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            Assert.Equals("VALID", testObject.ObjectState);
        }

        [Test]
        public void testValidRetrieve()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration((string)testObject.ObjectId);
            Assert.Equals(testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test]
        public void testValidRetrieveWithAddressImporter()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject_2();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration((string)testObject.ObjectId);
            Console.Write(retrievedObject.AddressImporter.IsComplete);
            Assert.Equals(testObject.ObjectId, retrievedObject.ObjectId);
            Assert.That(retrievedObject.AddressImporter != null);
            Assert.Equals(testObject.AddressImporter.ObjectId, retrievedObject.AddressImporter.ObjectId);
            Assert.Equals(true, retrievedObject.AddressImporter.IsComplete);
            Assert.Equals("Undefault New Wu", retrievedObject.AddressImporter.Name);
            Assert.Equals("Shippo", retrievedObject.AddressImporter.Company);
            Assert.Equals("", retrievedObject.AddressImporter.StreetNo);
            Assert.Equals("215 Clayton St", retrievedObject.AddressImporter.Street1);
            Assert.Equals("", retrievedObject.AddressImporter.Street2);
            Assert.Equals("", retrievedObject.AddressImporter.Street3);
            Assert.Equals("San Francisco", retrievedObject.AddressImporter.City);
            Assert.Equals("CA", retrievedObject.AddressImporter.State);
            Assert.Equals("94117-1913", retrievedObject.AddressImporter.Zip);
            Assert.Equals("US", retrievedObject.AddressImporter.Country);
            Assert.Equals("0015553419393", retrievedObject.AddressImporter.Phone);
            Assert.Equals("laura@goshipppo.com", retrievedObject.AddressImporter.Email);
            Assert.Equals(true, retrievedObject.AddressImporter.IsResidential);
            Assert.Equals(true, retrievedObject.AddressImporter.Test);
        }

        [Test]
        public void testListAll()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", "1");
            parameters.Add("page", "1");

            var parcels = apiResource.AllCustomsDeclarations(parameters);
            Assert.That(parcels.Data.Count > 0);
        }

        public static CustomsDeclaration getDefaultObject()
        {
            CustomsItem customsItem = CustomsItemTest.getDefaultObject();
            Hashtable parameters = new Hashtable();
            parameters.Add("exporter_reference", "");
            parameters.Add("importer_reference", "");
            parameters.Add("contents_type", "MERCHANDISE");
            parameters.Add("contents_explanation", "T-Shirt purchase");
            parameters.Add("invoice", "#123123");
            parameters.Add("license", "");
            parameters.Add("certificate", "");
            parameters.Add("notes", "");
            parameters.Add("eel_pfc", "NOEEI_30_37_a");
            parameters.Add("aes_itn", "");
            parameters.Add("non_delivery_option", "ABANDON");
            parameters.Add("certify", true);
            parameters.Add("certify_signer", "Laura Behrens Wu");
            parameters.Add("disclaimer", "");
            parameters.Add("incoterm", "");

            JArray customsItems = new JArray();
            customsItems.Add((string)customsItem.ObjectId);

            parameters.Add("items", customsItems);
            parameters.Add("metadata", "Order ID #123123");
            return getAPIResource().CreateCustomsDeclaration(parameters);
        }

        public static CustomsDeclaration getDefaultObject_2()
        {
            CustomsItem customsItem = CustomsItemTest.getDefaultObject();
            Address addressImporter = AddressTest.getDefaultObject();
            Hashtable parameters = new Hashtable();
            parameters.Add("exporter_reference", "");
            parameters.Add("importer_reference", "");
            parameters.Add("contents_type", "MERCHANDISE");
            parameters.Add("contents_explanation", "T-Shirt purchase");
            parameters.Add("invoice", "#123123");
            parameters.Add("license", "");
            parameters.Add("certificate", "");
            parameters.Add("notes", "");
            parameters.Add("eel_pfc", "NOEEI_30_37_a");
            parameters.Add("aes_itn", "");
            parameters.Add("non_delivery_option", "ABANDON");
            parameters.Add("certify", true);
            parameters.Add("certify_signer", "Laura Behrens Wu");
            parameters.Add("address_importer", addressImporter.ObjectId);
            parameters.Add("disclaimer", "");
            parameters.Add("incoterm", "");

            JArray customsItems = new JArray();
            customsItems.Add((string)customsItem.ObjectId);

            parameters.Add("items", customsItems);
            parameters.Add("metadata", "Order ID #123123");
            return getAPIResource().CreateCustomsDeclaration(parameters);
        }
    }
}

