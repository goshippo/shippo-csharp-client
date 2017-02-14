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
        private const String TRACKING_NO = "9205590164917337534322";
        private const String CARRIER = "usps";

        [Test ()]
        public void TestValidGetStatus ()
        {
            Track track = getAPIResource ().RetrieveTracking (CARRIER, TRACKING_NO);
            Assert.AreEqual (TRACKING_NO, track.TrackingNumber.ToString());
            Assert.IsNotNull (track.TrackingStatus);
            Assert.IsNotNull (track.TrackingHistory);
        }

        [Test ()]
        [ExpectedException (typeof (ShippoException))]
        public void TestInvalidGetStatus ()
        {
            getAPIResource ().RetrieveTracking (CARRIER, "INVALID_ID");
        }

        [Test ()]
        public void TestValidRegisterWebhook ()
        {
            Shipment shipment = ShipmentTest.getDefaultObject ();
            Track track = getAPIResource ().RetrieveTracking (CARRIER, shipment.ObjectId);
            Assert.IsNotNull (track.TrackingNumber);
            Assert.IsNotNull (track.TrackingHistory);

            Hashtable parameters = new Hashtable ();
            parameters.Add ("carrier", CARRIER);
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
            parameters.Add ("carrier", CARRIER);
            parameters.Add ("tracking_number", "INVALID_ID");
            getAPIResource ().RegisterTrackingWebhook (parameters);
        }
    }
}
