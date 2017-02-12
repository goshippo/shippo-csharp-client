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

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidGetStatus ()
        {
            getAPIResource ().RetrieveTracking ("usps", "INVALID_ID");
        }

        [Test ()]
        public void TestValidRegisterWebhook ()
        {
            Shipment shipment = ShipmentTest.getDefaultObject ();
            Tracking tracking = getAPIResource ().RetrieveTracking ("usps", shipment.ObjectId);
            Assert.IsNotNull (tracking.TrackingNumber);
            Assert.IsNotNull (tracking.TrackingHistory);

            Hashtable parameters = new Hashtable ();
            parameters.Add ("carrier", "usps");
            parameters.Add ("tracking_number", tracking.TrackingNumber);
            Tracking register = getAPIResource ().RegisterTrackingWebhook (parameters);
            Assert.IsNotNull (register.TrackingNumber);
            Assert.IsNotNull (register.TrackingHistory);
        }

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidRegisterWebhook ()
        {
            Hashtable parameters = new Hashtable ();
            parameters.Add ("carrier", "usps");
            parameters.Add ("tracking_number", "INVALID_ID");
            getAPIResource ().RegisterTrackingWebhook (parameters);
        }
    }
}
