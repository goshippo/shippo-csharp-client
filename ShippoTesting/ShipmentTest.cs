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
            Assert.AreEqual ("VALID", testObject.ObjectState);
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
            Hashtable parameters = new Hashtable ();
            parameters.Add ("results", "1");
            parameters.Add ("page", "1");

            var parcels = apiResource.AllShipments (parameters);
            Assert.AreNotEqual (0, parcels.Data.Count);
        }

        public static Shipment getDefaultObject ()
        {
            Hashtable parameters = new Hashtable ();
            Address addressFrom = AddressTest.getDefaultObject ();
            Address addressTo = AddressTest.getDefaultObject ();
            Parcel parcel = ParcelTest.getDefaultObject ();
            parameters.Add ("object_purpose", "QUOTE");
            parameters.Add ("address_from", addressFrom.ObjectId);
            parameters.Add ("address_to", addressTo.ObjectId);
            parameters.Add ("parcel", parcel.ObjectId);
            parameters.Add ("submission_type", "PICKUP");
            parameters.Add ("submission_date", "2013-12-03T12:00:00.000Z");
            parameters.Add ("insurance_amount", "30");
            parameters.Add ("insurance_currency", "USD");
            parameters.Add ("extra", "{signature_confirmation: true}");
            parameters.Add ("customs_declaration", "");
            parameters.Add ("reference_1", "");
            parameters.Add ("reference_2", "");
            parameters.Add ("metadata", "Customer ID 123456");

            return getAPIResource ().CreateShipment (parameters);
        }
    }
}

