using NUnit.Framework;
using System;
using System.Collections;
using Shippo;
using NUnit.Framework.Legacy;

namespace ShippoTesting
{
    [TestFixture]
    public class CarrierAccountTest : ShippoTest
    {
        [Test]
        public void TestValidRetrieve()
        {
            ShippoCollection<CarrierAccount> testObject = CarrierAccountTest.getDefaultObject();
            Assert.That(testObject.Data.Count > 0);
        }

        [Test]
        public void TestParametersRetreive()
        {
            ShippoCollection<CarrierAccount> testObject = CarrierAccountTest.getParameterObject();
            ClassicAssert.AreEqual(1, testObject.Data.Count);
        }

        public static ShippoCollection<CarrierAccount> getDefaultObject()
        {
            return getAPIResource().AllCarrierAccount();
        }

        public static ShippoCollection<CarrierAccount> getParameterObject()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", 1);
            return getAPIResource().AllCarrierAccount(parameters);
        }
    }
}