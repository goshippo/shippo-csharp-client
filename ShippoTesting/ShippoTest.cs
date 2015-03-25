using System;
using System.Collections;
using NUnit.Framework;
using Shippo;

namespace ShippoTesting {
    [TestFixture]
    public class ShippoTest {
        internal APIResource apiResource;
        public APIResource staticAPIResource;

        [SetUp] public void Init ()
        { 
            apiResource = new APIResource ("<Shippo Token>");
        }

        public static APIResource getAPIResource ()
        {
            return new APIResource ("<Shippo Token>");
        }

        public static Hashtable getInvalidHashtable ()
        {
            return new Hashtable ();
        }
    }
}


