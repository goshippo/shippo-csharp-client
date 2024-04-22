using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

using Shippo;
using NUnit.Framework.Legacy;


namespace ShippoTesting
{
    [TestFixture]
    public class CustomsDeclarationTest : ShippoTest
    {

        [Test]
        public void TestValidCreate()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            ClassicAssert.AreEqual(
"VALID", testObject.ObjectState);
        }

        [Test]
        public void testValidRetrieve()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration((string)testObject.ObjectId);
            ClassicAssert.AreEqual(
testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test]
        public void testValidRetrieveWithAddressImporter()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject_2();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration((string)testObject.ObjectId);
            Console.Write(retrievedObject.AddressImporter.IsComplete);
            ClassicAssert.AreEqual(
testObject.ObjectId, retrievedObject.ObjectId);
            Assert.That(retrievedObject.AddressImporter != null);
            ClassicAssert.AreEqual(
testObject.AddressImporter.ObjectId, retrievedObject.AddressImporter.ObjectId);
            ClassicAssert.AreEqual(
true, retrievedObject.AddressImporter.IsComplete);
            ClassicAssert.AreEqual(
"Undefault New Wu", retrievedObject.AddressImporter.Name);
            ClassicAssert.AreEqual(
"Shippo", retrievedObject.AddressImporter.Company);
            ClassicAssert.AreEqual(
"", retrievedObject.AddressImporter.StreetNo);
            ClassicAssert.AreEqual(
"215 Clayton St", retrievedObject.AddressImporter.Street1);
            ClassicAssert.AreEqual(
"", retrievedObject.AddressImporter.Street2);
            ClassicAssert.AreEqual(
"", retrievedObject.AddressImporter.Street3);
            ClassicAssert.AreEqual(
"San Francisco", retrievedObject.AddressImporter.City);
            ClassicAssert.AreEqual(
"CA", retrievedObject.AddressImporter.State);
            ClassicAssert.AreEqual("94117-1913", retrievedObject.AddressImporter.Zip);
            ClassicAssert.AreEqual(
"US", retrievedObject.AddressImporter.Country);
            ClassicAssert.AreEqual(
"0015553419393", retrievedObject.AddressImporter.Phone);
            ClassicAssert.AreEqual(
"laura@goshipppo.com", retrievedObject.AddressImporter.Email);
            ClassicAssert.AreEqual(
true, retrievedObject.AddressImporter.IsResidential);
            ClassicAssert.AreEqual(
true, retrievedObject.AddressImporter.Test);
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

