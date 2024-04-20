using NUnit.Framework;
using System;
using System.Net;
using Shippo;
using Microsoft.Extensions.Logging;

namespace ShippoTesting {
	[TestFixture]
	public class APIResourceTest : ShippoTest {
		public class MockAPIResource : APIResource
		{
			public MockAPIResource(ILogger logger, string inputToken) : base(logger, inputToken) {}
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
			MockAPIResource resource = new MockAPIResource(null, dummyApiToken);
			resource.SetApiVersion(dummyApiVersion);
			WebRequest request = resource.SetupRequestTest(dummyMethod, dummyUrl);
			Assert.Equals("ShippoToken " + dummyApiToken, request.Headers.Get("Authorization"));
			Assert.Equals(dummyApiVersion, request.Headers.Get("Shippo-API-Version"));
		}

		[Test]
		public void TestValidOAuthHeader() {
			String dummyMethod = "post";
			String dummyUrl = "http://example.com";
			String dummyApiToken = "oauth.abcdefffff.yyyyassaldjf=";
			String dummyApiVersion = "2018-02-08";
			MockAPIResource resource = new MockAPIResource(null, dummyApiToken);
			resource.SetApiVersion(dummyApiVersion);
			WebRequest request = resource.SetupRequestTest(dummyMethod, dummyUrl);
			Assert.Equals("Bearer " + dummyApiToken, request.Headers.Get("Authorization"));
			Assert.Equals(dummyApiVersion, request.Headers.Get("Shippo-API-Version"));
		}
	}

}
