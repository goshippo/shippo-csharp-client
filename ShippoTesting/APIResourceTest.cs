using NUnit.Framework;
using System;
using System.Net;

using Shippo;


namespace ShippoTesting {
	[TestFixture]
	public class APIResourceTest : ShippoTest {
		public class MockAPIResource : APIResource
		{
			public MockAPIResource(string inputToken) : base(inputToken) {}
			public WebRequest SetupRequestTest(String method, String url)
			{
				return SetupRequest(method, url);
			}
		}

		[Test]
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

		[Test]
		public void TestValidOAuthHeader() {
			String dummyMethod = "post";
			String dummyUrl = "http://example.com";
			String dummyApiToken = "oauth.abcdefffff.yyyyassaldjf=";
			String dummyApiVersion = "2018-02-08";
			MockAPIResource resource = new MockAPIResource(dummyApiToken);
			resource.SetApiVersion(dummyApiVersion);
			WebRequest request = resource.SetupRequestTest(dummyMethod, dummyUrl);
			Assert.AreEqual("Bearer " + dummyApiToken, request.Headers.Get("Authorization"));
			Assert.AreEqual(dummyApiVersion, request.Headers.Get("Shippo-API-Version"));
		}
	}

}
