using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class CustomsDeclarationTest : ShippoTest {

        [Test]
        public void TestValidCreate()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            Assert.AreEqual("VALID", testObject.ObjectState);
        }

        [Test]
        public void testValidRetrieve()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration((string) testObject.ObjectId);
            Assert.AreEqual(testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test]
        public void testValidRetrieveWithAddressImporter ()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject_2();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration ((string)testObject.ObjectId);
            Console.Write(retrievedObject.AddressImporter.IsComplete);
            Assert.AreEqual (testObject.ObjectId, retrievedObject.ObjectId);
            Assert.IsNotNull(retrievedObject.AddressImporter);
            Assert.AreEqual(testObject.AddressImporter.ObjectId, retrievedObject.AddressImporter.ObjectId);
            Assert.AreEqual(true, retrievedObject.AddressImporter.IsComplete);
            Assert.AreEqual("Undefault New Wu", retrievedObject.AddressImporter.Name);
            Assert.AreEqual("Shippo", retrievedObject.AddressImporter.Company);
            Assert.AreEqual("", retrievedObject.AddressImporter.StreetNo);
            Assert.AreEqual("215 Clayton St", retrievedObject.AddressImporter.Street1);
            Assert.AreEqual("", retrievedObject.AddressImporter.Street2);
            Assert.AreEqual("", retrievedObject.AddressImporter.Street3);
            Assert.AreEqual("San Francisco", retrievedObject.AddressImporter.City);
            Assert.AreEqual("CA", retrievedObject.AddressImporter.State);
            Assert.AreEqual("94117-1913", retrievedObject.AddressImporter.Zip);
            Assert.AreEqual("US", retrievedObject.AddressImporter.Country);
            Assert.AreEqual("0015553419393", retrievedObject.AddressImporter.Phone);
            Assert.AreEqual("laura@goshipppo.com", retrievedObject.AddressImporter.Email);
            Assert.AreEqual(true, retrievedObject.AddressImporter.IsResidential);
            Assert.AreEqual(true, retrievedObject.AddressImporter.Test);
        }

        [Test]
        public void testListAll()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", "1");
            parameters.Add("page", "1");

            var parcels = apiResource.AllCustomsDeclarations(parameters);
            Assert.AreNotEqual(0, parcels.Data.Count);
        }

        public static CustomsDeclaration getDefaultObject()
        {
            CustomsItem customsItem = CustomsItemTest.getDefaultObject();
            Address addressImporter = AddressTest.getDefaultObject ();
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
            customsItems.Add((string) customsItem.ObjectId);
            

            parameters.Add("items", customsItems);
            parameters.Add("metadata", "Order ID #123123");
            return getAPIResource().CreateCustomsDeclaration(parameters);
        }

        public static CustomsDeclaration getDefaultObject_2 ()
        {
            CustomsItem customsItem = CustomsItemTest.getDefaultObject();
            Address addressImporter = AddressTest.getDefaultObject();
            Hashtable parameters = new Hashtable ();
            parameters.Add ("exporter_reference", "");
            parameters.Add ("importer_reference", "");
            parameters.Add ("contents_type", "MERCHANDISE");
            parameters.Add ("contents_explanation", "T-Shirt purchase");
            parameters.Add ("invoice", "#123123");
            parameters.Add ("license", "");
            parameters.Add ("certificate", "");
            parameters.Add ("notes", "");
            parameters.Add ("eel_pfc", "NOEEI_30_37_a");
            parameters.Add ("aes_itn", "");
            parameters.Add ("non_delivery_option", "ABANDON");
            parameters.Add ("certify", true);
            parameters.Add ("certify_signer", "Laura Behrens Wu");
            parameters.Add ("address_importer", addressImporter.ObjectId);
            parameters.Add ("disclaimer", "");
            parameters.Add ("incoterm", "");

            JArray customsItems = new JArray ();
            customsItems.Add ((string)customsItem.ObjectId);


            parameters.Add ("items", customsItems);
            parameters.Add ("metadata", "Order ID #123123");
            return getAPIResource ().CreateCustomsDeclaration (parameters);
        }
    }
}

