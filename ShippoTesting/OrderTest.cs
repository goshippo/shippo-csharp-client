using NUnit.Framework;
using System;
using System.Collections;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class OrderTest : ShippoTest {

        [Test]
        public void TestValidCreate()
        {
            Order testObject = OrderTest.getDefaultObject();
            Assert.IsNotNull(testObject.ObjectId);
        }

        [Test]
        public void testValidRetrieve()
        {
            Order testObject = OrderTest.getDefaultObject();
            Order retrievedObject;

            retrievedObject = apiResource.RetrieveOrder((string) testObject.ObjectId);
            Assert.AreEqual(testObject.ObjectId, retrievedObject.ObjectId);
        }

        [Test]
        public void testListAll()
        {
            Hashtable parameters = new Hashtable();
            parameters.Add("results", "1");
            parameters.Add("page", "1");

            var parcels = apiResource.AllOrders(parameters);
            Assert.AreNotEqual(0, parcels.Data.Count);
        }

        public static Order getDefaultObject()
        {
            Address addressFrom = AddressTest.getDefaultObject();
            Address addressTo = AddressTest.getDefaultObject_2();
            Hashtable items = new Hashtable();
            items.Add("total_amount", "10.45");
            items.Add("weight_unit", "kg");
            items.Add("title", "package");
            List<Hashtable> lineItems = new List<Hashtable>();
            lineItems.Add(items);            

            Hashtable parameters = new Hashtable();
            parameters.Add("total_tax", "0.00");
            parameters.Add("from_address", addressFrom.ObjectId);
            parameters.Add("to_address", addressTo.ObjectId);
            parameters.Add("line_items", lineItems);
            parameters.Add("shipping_method", null);
            parameters.Add("weight", 0);
            parameters.Add("shop_app", "Shippo");
            parameters.Add("currency", "USD");
            parameters.Add("shipping_cost_currency", "USD");
            parameters.Add("shipping_cost", null);
            parameters.Add("subtotal_price", "0");
            parameters.Add("total_price", "0");
            parameters.Add("order_status", "PAID");
            parameters.Add("hidden", false);
            parameters.Add("order_number", "LOREM #1");
            parameters.Add("weight_unit", "kg");
            parameters.Add("placed_at", "2020-11-12T23:59:59");

            return getAPIResource().CreateOrder(parameters);
        }
    }
}
