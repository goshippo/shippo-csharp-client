using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Shippo;

namespace ShippoTesting
{
    [TestFixture ()]
    public class TrackingTest : ShippoTest
    {
        [Test ()]
        public void TestValidGetStatus ()
        {
            Shipment shipment = ShipmentTest.getDefaultObject ();
            Tracking tracking = getAPIResource ().RetrieveTracking ("usps", shipment.ObjectId);
            Assert.IsNotNull (tracking.TrackingNumber);
            Assert.IsNotNull (tracking.TrackingHistory);
        }
    }
}
