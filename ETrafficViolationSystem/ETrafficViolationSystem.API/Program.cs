using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Reflection;

namespace ETrafficViolationSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureAppConfiguration((hostContext, config) =>
                {
                    config.SetBasePath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
                    config.AddJsonFile("appsettings.json", optional: true, false);
                    config.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json",
                        optional: true, reloadOnChange: true);
                    config.AddEnvironmentVariables();
                });
    }
}
