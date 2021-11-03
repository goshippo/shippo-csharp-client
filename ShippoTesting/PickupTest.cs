using NUnit.Framework;
using System;
using System.Collections;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class PickupTest : ShippoTest {
    /* Intentionally commented; cannot be tested without proper billing credentials
        
        [Test]
        public void TestValidCreate()
        {
            Hashtable transactionParameters = new Hashtable();
            Shipment shipment = ShipmentTest.getDefaultObject();
            var rate = shipment.Rates[0];

            transactionParameters.Add("rate", rate.ObjectId);
            transactionParameters.Add("async", false);
            transactionParameters.Add("label_file_type", "PDF");
            Transaction transaction = getAPIResource().CreateTransactionSync(transactionParameters);
            
            Hashtable location = new Hashtable();
            location.Add("building_location_type", "Knock on Door");
            location.Add("address", shipment.AddressTo);

            var pickupStartTime = DateTime.UtcNow;
            var pickupEndTime = pickupStartTime.AddDays(1);

            Hashtable parameters = new Hashtable();
            parameters.Add("carrier_account", rate.ObjectId);
            parameters.Add("location", location);
            parameters.Add("transactions", new String[]{ transaction.ObjectId });
            parameters.Add("requested_start_time", pickupStartTime.ToString("o"));
            parameters.Add("requested_end_time", pickupEndTime.ToString("o"));
            parameters.Add("is_test", false);

            Pickup testObject = getAPIResource().CreatePickup(parameters);
            Assert.AreEqual("SUCCESS", testObject.Status);
        }
    }*/
}