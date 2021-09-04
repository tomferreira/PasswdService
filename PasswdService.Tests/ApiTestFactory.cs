using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using Moq;
using System.Collections.Generic;
using System.IO;

namespace PasswdService.Tests
{
    class ApiTestFactory
    {
        private static Dictionary<string, StringValues> CreateDictionary(string key, string value)
        {
            var qs = new Dictionary<string, StringValues>
            {
                { key, value }
            };

            return qs;
        }

        public static Mock<HttpRequest> CreateMockPostRequest(string body)
        {
            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);

            sw.Write(body);
            sw.Flush();

            ms.Position = 0;

            var mockRequest = new Mock<HttpRequest>();
            mockRequest.Setup(x => x.Body).Returns(ms);

            return mockRequest;
        }

        public static ILogger CreateLogger()
        {
            return NullLoggerFactory.Instance.CreateLogger("Null Logger");
        }
    }
}
