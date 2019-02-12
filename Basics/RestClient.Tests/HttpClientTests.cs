using System;
using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RestClient.Tests
{
    [TestClass]
    public class HttpClientTests
    {
        [TestMethod]
        public void TestGetAsync()
        {
            HttpClient client = new HttpClient();
            var resp = client.GetAsync(@"http://tommyedi.dnsalias.com:55555/bondi/teste/public");
            Console.WriteLine(resp.Result.StatusCode.ToString());
            Console.WriteLine(resp.Result.Headers.CacheControl.ToString());

            Console.WriteLine(resp.Result.Content.ReadAsStringAsync().Result.ToString());


        }
    }

    
}
