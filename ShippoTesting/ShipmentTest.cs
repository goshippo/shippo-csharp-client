using NUnit.Framework;
using System;
using System.Collections;
using Shippo;

namespace ShippoTesting {
    [TestFixture ()]
    public class ShipmentTest : ShippoTest {

        [Test ()]
        public void TestValidCreate ()
        {
            Shipment testObject = ShipmentTest.getDefaultObject ();
            Assert.AreEqual ("SUCCESS", testObject.Status);
        }

        [Test ()]
        public void testValidRetrieve ()
        {
            Shipment testObject = ShipmentTest.getDefaultObject ();
            Shipment retrievedObject;

            retrievedObject = apiResource.RetrieveShipment ((string) testObject.ObjectId);
            Assert.AreEqual (testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test ()]
        public void testListAll ()
        {
            Dictionary<String, Object> parameters = new Dictionary<String, Object> ();
            parameters.Add ("results", "1");
            parameters.Add ("page", "1");

            var parcels = apiResource.AllShipments (parameters);
            Assert.AreNotEqual (0, parcels.Data.Count);
        }

        public static Shipment getDefaultObject ()
        {
            Dictionary<String, Object> parameters = new Dictionary<String, Object> ();
            Address addressFrom = AddressTest.getDefaultObject ();
            Address addressTo = AddressTest.getDefaultObject_2 ();
            Parcel parcel = ParcelTest.getDefaultObject ();
            parameters.Add ("address_from", addressFrom.ObjectId);
            parameters.Add ("address_to", addressTo.ObjectId);
            parameters.Add ("parcels", new String[]{ parcel.ObjectId});
            parameters.Add ("shipment_date", "2013-12-03T12:00:00.000Z");
            parameters.Add ("insurance_amount", "30");
            parameters.Add ("insurance_currency", "USD");
            parameters.Add ("extra", "{signature_confirmation: true}");
            parameters.Add ("customs_declaration", "");
            parameters.Add ("metadata", "Customer ID 123456");
            parameters.Add ("async", false);

            return getAPIResource ().CreateShipment (parameters);
        }
    }
}

