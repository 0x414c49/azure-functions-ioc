using AzureFunctions.Ioc.Configurations;
using AzureFunctions.Ioc.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureFunctions.Ioc.Startup))]

namespace AzureFunctions.Ioc
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
            builder.Services.AddOptions<AppInfo>()
                            .Configure<IConfiguration>((settings, configuration)
                                => configuration.GetSection("AppInfo").Bind(settings));

            builder.Services.AddTransient<IHelloWorld, HelloWorld>();

        }
    }
}