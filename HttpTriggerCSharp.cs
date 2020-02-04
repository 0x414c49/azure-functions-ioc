using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using AzureFunctions.Ioc.Configurations;
using AzureFunctions.Ioc.Services;
using Microsoft.Extensions.Options;

namespace AzureFunctions.Ioc
{
    public class HttpTriggerCSharp
    {
        private readonly AppInfo _settings;
        private readonly IHelloWorld _helloWorld ;

        public HttpTriggerCSharp(IOptions<AppInfo> settings, IHelloWorld helloWorld)
        {
            _settings = settings.Value;
            _helloWorld = helloWorld;
        }

        [FunctionName("Hello")]
        public async Task<IActionResult> Hello(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            if (_settings.LogInformation)
                log.LogInformation("C# HTTP trigger function processed a request.");

            var name = req.Query["name"];

            if (string.IsNullOrEmpty(name))
                return new BadRequestObjectResult("Please pass a name on the query string.");
            return await Task.FromResult(new OkObjectResult(_helloWorld.SayHello(name)));
        }
    }
}