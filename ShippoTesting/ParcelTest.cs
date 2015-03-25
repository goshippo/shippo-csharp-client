using NUnit.Framework;
using System;
using System.Collections;
using Shippo;

namespace ShippoTesting {
    [TestFixture ()]
    public class ParcelTest : ShippoTest {

        [Test ()]
        public void TestValidCreate ()
        {
            Parcel testObject = ParcelTest.getDefaultObject ();
            Assert.AreEqual ("VALID", testObject.ObjectState);
        }

        [Test ()]
        public void testValidRetrieve ()
        {
            Parcel testObject = ParcelTest.getDefaultObject ();
            Parcel retrievedObject;

            retrievedObject = apiResource.RetrieveParcel ((string) testObject.ObjectId);
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

        public static Parcel getDefaultObject ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("length", "5");
            parameters.Add ("width", "5");
            parameters.Add ("height", "5");
            parameters.Add ("distance_unit", "cm");
            parameters.Add ("weight", "2");
            parameters.Add ("mass_unit", "lb");
            parameters.Add ("template", null);
            parameters.Add ("metadata", "Customer ID 123456");

            return getAPIResource ().CreateParcel (parameters);
        }
    }
}

