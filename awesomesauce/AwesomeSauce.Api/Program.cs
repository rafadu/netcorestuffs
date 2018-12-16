using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Server.WebListener;
using AwesomeSauce.Api.Microsoft.AspNetCore.Hosting;

namespace AwesomeSauce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
            //BuildWebHost(args).Run();
            BuildWebHostAwesome(args).Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static IWebHost BuildWebHost(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(
                    config => config.AddJsonFile("appsettings.json",true)
                )
                .ConfigureLogging(
                    logging => logging
                        .AddConsole()
                        .AddDebug()
                )
                .UseIISIntegration()
                .UseStartup<Foo>()
                .Build();

        // public static IWebHostBuilder UseHttpSys(this IWebHostBuilder hostBuilder){
        //     return hostBuilder.ConfigureServices(
        //         services => {
        //             services.AddSingleton<IServer,MessagePump>();
        //         }
        //     );
        // }
        public static IWebHost BuildWebHostAwesome(string[] args) => WebHost.CreateDefaultBuilder(args)
                .UseAwesomeServer(o => o.FolderPath = @"/home/rafadu/sandbox/in")
                .UseStartup<Startup>()
                .Build();
    }
}
