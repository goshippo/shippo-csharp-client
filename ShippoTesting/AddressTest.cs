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
            Assert.AreEqual (true, testObject.IsComplete);
        }

        [Test ()]
        public void testValidRetrieve ()
        {
            Address testObject = AddressTest.getDefaultObject ();
            Address retrievedObject;

            retrievedObject = apiResource.RetrieveAddress ((string) testObject.ObjectId);
            Assert.AreEqual (testObject.ObjectId, retrievedObject.ObjectId);
        }

        public static Address getDefaultObject ()
        {
            Hashtable parameters = new Hashtable ();
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
		public static Address getDefaultObject_2 ()
		{
			Hashtable parameters = new Hashtable ();
			parameters.Add ("name", "Undefault New Wu");
			parameters.Add ("company", "Shippo");
			parameters.Add ("street1", "Francis St.");
			parameters.Add ("street_no", "56");
			parameters.Add ("street2", null);
			parameters.Add ("city", "San Francisco");
			parameters.Add ("state", "CA");
			parameters.Add ("zip", "94112");
			parameters.Add ("country", "US");
			parameters.Add ("phone", "+1 555 341 9393");
			parameters.Add ("email", "laura@goshipppo.com");
			parameters.Add ("metadata", "Customer ID 123456");
			return getAPIResource ().CreateAddress (parameters);
		}
    }
}

