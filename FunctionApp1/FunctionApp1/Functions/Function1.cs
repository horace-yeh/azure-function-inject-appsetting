using FunctionApp1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace FunctionApp1.Functions
{
    public class Function1
    {
        private readonly AppSettings _appSettings;

        public Function1(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [FunctionName("Function1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string responseMessage = _appSettings.Test1;

            return new OkObjectResult(responseMessage);
        }
    }
}
