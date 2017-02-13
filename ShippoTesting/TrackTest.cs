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
    public class TrackTest : ShippoTest
    {
        [Test ()]
        public void TestValidGetStatus ()
        {
            Shipment shipment = ShipmentTest.getDefaultObject ();
            Track track = getAPIResource ().RetrieveTracking ("usps", shipment.ObjectId);
            Assert.IsNotNull (track.TrackingNumber);
            Assert.IsNotNull (track.TrackingHistory);
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
            Track track = getAPIResource ().RetrieveTracking ("usps", shipment.ObjectId);
            Assert.IsNotNull (track.TrackingNumber);
            Assert.IsNotNull (track.TrackingHistory);

            Hashtable parameters = new Hashtable ();
            parameters.Add ("carrier", "usps");
            parameters.Add ("tracking_number", track.TrackingNumber);
            Track register = getAPIResource ().RegisterTrackingWebhook (parameters);
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
