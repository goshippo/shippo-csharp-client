using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;
using System.Threading;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class UserParcelTemplateTest : ShippoTest
    {
        internal static string UserParcelTemplateObjectId;

        [Test, Order(1)]
        public void TestValidCreate()
        {

            Hashtable parameters = UserParcelTemplateTest.getParameterObject();
            UserParcelTemplate testObject = getAPIResource().CreateUserParcelTemplate(parameters);
            Assert.AreEqual(parameters["name"], testObject.Name);

            UserParcelTemplateObjectId = testObject.ObjectId;
        }

        [Test, Order(2)]
        public void TestValidUpdate()
        {
            Hashtable parameters = UserParcelTemplateTest.getParameterObject_2();
            UserParcelTemplate testObject = getAPIResource().UpdateUserParcelTemplate(UserParcelTemplateObjectId, parameters);
            Assert.AreEqual(parameters["length"], testObject.Length);
        }

        [Test, Order(3)]
        public void TestValidRetrieve()
        {
            UserParcelTemplate testObject = getAPIResource().RetrieveUserParcelTemplate(UserParcelTemplateObjectId);
            Assert.AreEqual(UserParcelTemplateObjectId, testObject.ObjectId);
        }

        [Test, Order(4)]
        public void TestValidRetrieveAll()
        {
            ShippoCollection<UserParcelTemplate> testObject = getAPIResource().AllUserParcelTemplates();
            Assert.GreaterOrEqual(testObject.Data.Count, 1);
        }

        [Test, Order(5)]
        public void TestValidDelete()
        {
            getAPIResource().DeleteUserParcelTemplate(UserParcelTemplateObjectId);
            ShippoCollection<UserParcelTemplate> testObject = getAPIResource().AllUserParcelTemplates();
            Assert.IsTrue(testObject.Data.All(d => d.ObjectId != UserParcelTemplateObjectId));
        }

        public static Hashtable getParameterObject()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("length", "5");
            parameters.Add("width", "5");
            parameters.Add("height", "5");
            parameters.Add("distance_unit", "in");
            parameters.Add("name", "Unit Test Parcel Template 1");
            return parameters;
        }

        public static Hashtable getParameterObject_2()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("length", "10");
            parameters.Add("width", "15");
            parameters.Add("height", "20");
            parameters.Add("distance_unit", "in");
            parameters.Add("name", "Unit Test Parcel Template 2");
            return parameters;
        }
    }
}

