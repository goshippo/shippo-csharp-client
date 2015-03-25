using NUnit.Framework;
using System;
using System.Collections;
using Shippo;

namespace ShippoTesting {
    [TestFixture ()]
    public class AddressTest : ShippoTest {

        [Test ()]
        public void TestValidCreate ()
        {
            Address testObject = AddressTest.getDefaultObject ();
            Assert.AreEqual ("VALID", testObject.ObjectState);
        }

        [Test ()]
        public void testValidRetrieve ()
        {
            Address testObject = AddressTest.getDefaultObject ();
            Address retrievedObject;

            retrievedObject = apiResource.RetrieveAddress ((string) testObject.ObjectId);
            Assert.AreEqual (testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test ()]
        public void testListAll ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("results", "1");
            parameters.Add ("page", "1");

            var parcels = apiResource.AllParcels (parameters);
            Assert.AreNotEqual (0, parcels.Data.Count);
        }

        public static Address getDefaultObject ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("object_purpose", "QUOTE");
            parameters.Add ("name", "Undefault New Wu");
            parameters.Add ("company", "Shippo");
            parameters.Add ("street1", "Clayton St.");
            parameters.Add ("street_no", "215");
            parameters.Add ("street2", null);
            parameters.Add ("city", "San Francisco");
            parameters.Add ("state", "CA");
            parameters.Add ("zip", "94117");
            parameters.Add ("country", "US");
            parameters.Add ("phone", "+1 555 341 9393");
            parameters.Add ("email", "laura@goshipppo.com");
            parameters.Add ("metadata", "Customer ID 123456");
            return getAPIResource ().CreateAddress (parameters);
        }
    }
}

