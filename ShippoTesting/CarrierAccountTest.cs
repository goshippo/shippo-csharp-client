using NUnit.Framework;
using System;
using System.Collections;

using Shippo;

namespace ShippoTesting
{
    [TestFixture]
    public class CarrierAccountTest : ShippoTest {
        [Test]
        public void TestValidRetrieve()
        {
            ShippoCollection<CarrierAccount> testObject = CarrierAccountTest.getDefaultObject();
            Assert.Greater(testObject.Data.Count, 0);
        }

        [Test]
        public void TestParametersRetreive()
        {
            ShippoCollection<CarrierAccount> testObject = CarrierAccountTest.getParameterObject();
            Assert.AreEqual(1, testObject.Data.Count);
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