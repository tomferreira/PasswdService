using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace PasswdService.App
{
    public static class CheckerAPI
    {
        [FunctionName("Checker")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Admin, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("HTTP trigger function Checker processed a request.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            ApiRequestData data;

            try
            {
                data = JsonConvert.DeserializeObject<ApiRequestData>(requestBody);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                return new BadRequestResult();
            }

            var result = Domain.Checker.IsValid(data?.password);

            return new OkObjectResult(
                new ApiResponseData { Result = result.ToString() });
        }
    }
}
