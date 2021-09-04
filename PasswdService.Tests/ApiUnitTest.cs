using Microsoft.AspNetCore.Mvc;
using PasswdService.App;
using Xunit;

namespace PasswdService.Tests
{
    public class ApiUnitTest
    {
        [Fact]
        public async void Http_Trigger_Should_Return_Valid()
        {
            var request = ApiTestFactory.CreateMockPostRequest("{password: \"Abcdefg1+\"}");

            var response = await CheckerAPI.Run(request.Object, ApiTestFactory.CreateLogger());

            Assert.IsType<OkObjectResult>(response);

            Assert.Equal("Valid", ((response as OkObjectResult).Value as ApiResponseData).Result);
        }

        [Fact]
        public async void Http_Trigger_Bad_Formatted_Should_Return_BadRequest()
        {
            var request = ApiTestFactory.CreateMockPostRequest("password: \"Abcdefg1+\"}");

            var response = await CheckerAPI.Run(request.Object, ApiTestFactory.CreateLogger());

            Assert.IsType<BadRequestResult>(response);
        }
    }
}
