using NUnit.Framework;
using System;
using Shippo;
using System.Net;

namespace ShippoTesting {
	[TestFixture()]
	public class APIResourceTest : ShippoTest {
		public class MockAPIResource : APIResource
		{
			public MockAPIResource(string inputToken) : base(inputToken)
			{
			}
			public WebRequest SetupRequestTest(String method, String url)
			{
				return SetupRequest(method, url);
			}
		}

		[Test()]
		public void TestValidHeader() {
			String dummyMethod = "post";
			String dummyUrl = "http://example.com";
			String dummyApiToken = "1234abcd";
			String dummyApiVersion = "2014-02-11";
			MockAPIResource resource = new MockAPIResource(dummyApiToken);
			resource.SetApiVersion(dummyApiVersion);
			WebRequest request = resource.SetupRequestTest(dummyMethod, dummyUrl);
			Assert.AreEqual("ShippoToken " + dummyApiToken, request.Headers.Get("Authorization"));
			Assert.AreEqual(dummyApiVersion, request.Headers.Get("Shippo-API-Version"));
		}
	}

}
