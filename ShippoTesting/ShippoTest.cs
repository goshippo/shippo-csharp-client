using NUnit.Framework;
using System;
using System.Collections;
using Shippo;
using System.IO;
using Microsoft.Extensions.Logging;

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
            var root = Directory.GetCurrentDirectory();
            Console.WriteLine($"dir: {root}");

            var dotenv = Path.Combine(root, ".env");
            DotEnv.Load(dotenv);

            String token = Environment.GetEnvironmentVariable("Wrapper_Token");
            Console.WriteLine($"Token: {token}");
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            ILogger logger = factory.CreateLogger("Program");
            apiResource = new APIResource(logger, token);
            liveAPI = new APIResource(logger, Environment.GetEnvironmentVariable("Live_Token"));
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


