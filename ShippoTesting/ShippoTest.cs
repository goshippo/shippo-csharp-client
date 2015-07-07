using System;
using System.Collections;
using NUnit.Framework;
using Shippo;

namespace ShippoTesting {
    [TestFixture]
    public class ShippoTest {
		static internal APIResource apiResource;
        public APIResource staticAPIResource;

        [SetUp] public void Init ()
        { 
			apiResource = new APIResource ("<Shippo Token>");
        }

        public static APIResource getAPIResource ()
        {
			return apiResource;
        }

        public static Hashtable getInvalidHashtable ()
        {
            return new Hashtable ();
        }
    }
}


