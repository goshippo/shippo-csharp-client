using NUnit.Framework;
using System;
using System.Collections;
using System.Threading;
using Shippo;

namespace ShippoTesting {
    [TestFixture ()]
    public class RateTest : ShippoTest {

        [Test ()]
        public void TestValidCreate ()
        {
            ShippoCollection<Rate> testObject = RateTest.getDefaultObject ();
            Assert.NotNull (testObject.Data);
        }

        [Test ()]
        public void testListAll ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("results", "1");
            parameters.Add ("page", "1");

            var parcels = apiResource.AllRates (parameters);
            Assert.AreNotEqual (0, parcels.Data.Count);
        }

        public static ShippoCollection<Rate> getDefaultObject ()
        {
            Shipment testObject = ShipmentTest.getDefaultObject ();
            Hashtable parameters = new Hashtable ();
            parameters.Add ("id", testObject.ObjectId);
            parameters.Add ("currency_code", "USD");

            // Use Synchronized rates method
            return getAPIResource ().GetShippingRatesSync (parameters);
        }
    }
}

