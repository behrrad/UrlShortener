using System;
using Xunit;
using RA;

namespace tests
{
    public class UnitTest1
    {

        private const string API = "http://localhost:5000";
        [Fact]
        public void Test1()
        {
            new RestAssured()
            .Given()
                .Name("test post endpoint")
                .Header("Content-Type","application/json")
                .Body(new {url = "google.com"})
            .When()
                .Post(API + "/urls")
            .Then()
                .TestStatus("test status", status => {Console.WriteLine(status); return status == 200;} )
                .Assert("test status")
                .TestBody("test body", body => ((string)body.shortUrl).Length == 8 )
                .Assert("test body");

        }
    }
}
