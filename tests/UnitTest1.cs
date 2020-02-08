using System;
using Xunit;
using RA;

namespace tests
{
    public class UnitTest1
    {

        private const string API = "http://localhost:5000";
        [Fact]
        public void TestSimpleUrlWithoutWww()
        {
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status")
              .TestBody("test body", body => ((string)body.shortUrl).Length == 8 )
              .Assert("test body");
        }
        [Fact]
        public void TestSimpleUrlWithWww()
        {
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "www.google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        }
        [Fact]
        public void TestUrlWithHttp(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "http://google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        } 
        [Fact]           
        public void TestUrlWithHttpAndWww(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "http://www.google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
            
        }
        [Fact]
        public void TestUrlWithHttps(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "https://google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        }
        [Fact]
        public void TestUrlWithHttpsAndWww(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "https://www.google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        }
        [Fact]
        public void DoubleDot(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "https://www..google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 400)
              .Assert("test status");
        }
        [Fact]
        public void TestDoubleDash(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "https://www.google--varzesh.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 400)
              .Assert("test status");
        }
            
        [Fact]
        public void TestPersionWord(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {url = "https://www.varzesh3.com/behrad/mamad/vahid/سوال/reza.cs"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        }
        [Fact]
        public void BadRequestForGet(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
            .When()
              .Get(API + "/21AAAAAA")
            .Then()
              .TestStatus("test status", status => status == 400)
              .Assert("test status");
        }
        [Fact]
        public void NotFoundForGet(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
            .When()
              .Get(API + "/AAAAAAAA")
            .Then()
              .TestStatus("test status", status => status == 404)
              .Assert("test status");
        }
    }
}
