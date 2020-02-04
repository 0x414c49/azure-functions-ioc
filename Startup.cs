using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(azure_functions_ioc.Startup))]

namespace azure_functions_ioc
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // builder.Services.AddHttpClient();

            // builder.Services.AddSingleton((s) => {
            //     return new MyService();
            // });

            // builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }
    }
}