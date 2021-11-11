using System.IO;
using MatrixAgent.ConfigData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;


namespace MatrixAgent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddCommandLine(args)
                .Build();

            var url = 
                config.GetSection(ApplicationUrlOptions.ApplicationUrl)
                    .Get<ApplicationUrlOptions>().BasePath;

            CreateHostBuilder(args, url).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args, string url) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls(url);
                }).UseWindowsService();
    }
}
