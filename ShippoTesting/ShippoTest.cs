using NUnit.Framework;
using System;
using System.Collections;

using Shippo;


namespace ShippoTesting {
    [TestFixture]
    public class ShippoTest {
		static internal APIResource apiResource;
        static internal String now;
        public APIResource staticAPIResource;

        [SetUp] public void Init()
        {
            apiResource = new APIResource("<Shippo Token>");
            now = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
        }

        public static APIResource getAPIResource()
        {
            return apiResource;
        }

        public static Hashtable getInvalidHashtable()
        {
            return new Hashtable();
        }
    }
}


