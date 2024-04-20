using NUnit.Framework;
using System;
using System.Collections;

using Shippo;


namespace ShippoTesting
{
    [TestFixture]
    public class TrackTest : ShippoTest
    {
        private static readonly String TRACKING_NO = "SHIPPO_TRANSIT";
        private static readonly String CARRIER = "shippo";

        [Test]
        public void TestValidGetStatus()
        {
            Track track = getAPIResource().RetrieveTracking(CARRIER, TRACKING_NO);
            Assert.Equals(TRACKING_NO, track.TrackingNumber);
            Assert.That(track.TrackingStatus!=null);
            Assert.That(track.TrackingHistory!=null);
        }

        [Test]
        public void TestInvalidGetStatus()
        {
            Assert.That(() => getAPIResource().RetrieveTracking(CARRIER, "INVALID_ID"),
                        Throws.TypeOf<ShippoException>());
        }

        [Test]
        public void TestValidRegisterWebhook()
        {
            Track track = getAPIResource().RetrieveTracking(CARRIER, TRACKING_NO);

            Hashtable parameters = new Hashtable();
            parameters.Add("carrier", CARRIER);
            parameters.Add("tracking_number", track.TrackingNumber);
            Track register = getAPIResource().RegisterTrackingWebhook(parameters);
            Assert.That(register.TrackingNumber !=null);
            Assert.That(register.TrackingHistory!=null);
        }

        [Test]
        public void TestInvalidRegisterWebhook()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("carrier", CARRIER);
            parameters.Add("tracking_number", "INVALID_ID");
            Assert.That(() => getAPIResource().RegisterTrackingWebhook(parameters),
                        Throws.TypeOf<ShippoException>());
        }
    }
}
