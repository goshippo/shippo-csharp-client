using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shippo;

namespace ShippoTesting {
    [TestFixture ()]
    public class CustomsDeclarationTest : ShippoTest {

        [Test ()]
        public void TestValidCreate ()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject ();
            Assert.AreEqual ("VALID", testObject.ObjectState);
        }

        [Test ()]
        public void testValidRetrieve ()
        {
            CustomsDeclaration testObject = CustomsDeclarationTest.getDefaultObject ();
            CustomsDeclaration retrievedObject;

            retrievedObject = apiResource.RetrieveCustomsDeclaration ((string) testObject.ObjectId);
            Assert.AreEqual (testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test ()]
        public void testListAll ()
        {
            Dictionary<String, Object> parameters = new Dictionary<String, Object> ();
            parameters.Add ("results", "1");
            parameters.Add ("page", "1");

            var parcels = apiResource.AllCustomsDeclarations (parameters);
            Assert.AreNotEqual (0, parcels.Data.Count);
        }

        public static CustomsDeclaration getDefaultObject ()
        {
            CustomsItem customsItem = CustomsItemTest.getDefaultObject ();
            Dictionary<String, Object> parameters = new Dictionary<String, Object> ();
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
            parameters.Add ("disclaimer", "");
            parameters.Add ("incoterm", "");

            
            JArray customsItems = new JArray ();
            customsItems.Add ((string) customsItem.ObjectId);
            

            parameters.Add ("items", customsItems);
            parameters.Add ("metadata", "Order ID #123123");
            return getAPIResource ().CreateCustomsDeclaration (parameters);
        }
    }
}

