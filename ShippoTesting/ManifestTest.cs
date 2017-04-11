using NUnit.Framework;
using System;
using System.Collections;
using Shippo;

namespace ShippoTesting {
    [TestFixture ()]
    public class ManifestTest : ShippoTest {

        [Test ()]
        public void TestInvalidCreate ()
        {
			Assert.That (() => ManifestTest.getDefaultObject (),Throws.TypeOf<ShippoException> ());
        }

        [Test ()]
        public void testValidRetrieve ()
        {
            Manifest testObject = ManifestTest.getDefaultObject ();
            Manifest retrievedObject;

            retrievedObject = apiResource.RetrieveManifest ((string) testObject.ObjectId);
            Assert.AreEqual (testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test ()]
        public void testListAll ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("results", "1");
            parameters.Add ("page", "1");

            var Manifests = apiResource.AllManifests (parameters);
            Assert.AreEqual (0, Manifests.Data.Count);
        }

        public static Manifest getDefaultObject ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("provider", "USPS");
            parameters.Add ("shipment_date", "2014-05-16T23:59:59Z");
            parameters.Add ("address_from", AddressTest.getDefaultObject ().ObjectId);

            return getAPIResource ().CreateManifest (parameters);
        }
    }
}

