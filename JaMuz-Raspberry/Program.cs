using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace JaMuzRaspberry;

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
                webBuilder
                .UseUrls("https://192.168.1.145:8080")
                .UseStartup<Startup>();
            });
}
