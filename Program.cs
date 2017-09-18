using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace core_hystrix_wrapper_ui
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        /* public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.ConfigureAppConfiguration((builderContext, config) =>
                //{
                //    IHostingEnvironment env = builderContext.HostingEnvironment;

                //    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                //})
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5002/")
                .Build();
    } */

    public static IWebHost BuildWebHost(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)  // add custom config file
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(config)  // include reference to config
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5002/")
                .Build();
        }
    }

}
