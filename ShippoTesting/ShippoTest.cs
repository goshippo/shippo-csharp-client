using Shippo;
using System.Collections;


namespace ShippoTesting
{
    [TestFixture]
    public class ShippoTest
    {
        static internal APIResource apiResource;
        static internal APIResource liveAPI;
        static internal Boolean live;
        static internal String now;
        public APIResource staticAPIResource;

        [SetUp]
        public void Init()
        {
            String token = Environment.GetEnvironmentVariable("Wrapper_Token");
            apiResource = new APIResource(token);
            liveAPI = new APIResource(Environment.GetEnvironmentVariable("Live_Token"));
            now = DateTime.Now.ToString("yyyy-MM-dd HH':'mm':'ss");
            live = false;
        }

        public static APIResource getAPIResource()
        {
            return live ? liveAPI : apiResource;
        }

        public static void setLive(Boolean live_api = true)
        {
            live = live_api;
        }

        public static Hashtable getInvalidHashtable()
        {
            return new Hashtable();
        }
    }
}


