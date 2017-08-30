using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace web
{
    public class Program
    {
        private static IConfigurationRoot _configuration;

        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddCommandLine(args);
            _configuration = builder.Build();
            var host = new WebHostBuilder()
                .UseConfiguration(_configuration)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .ConfigureServices(ConfigureServices)                
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        private static void ConfigureServices(IServiceCollection obj)
        {
            //настройка инъекций
            obj.AddDbContext<data.nsi.nsiContext>((opt)=>data.nsi.nsiContext.Configure(opt,_configuration.GetConnectionString("AsuPrint")));
            obj.AddDbContext<printer.Database.PrinterContext>((opt)=>printer.Database.PrinterContext.Configure(opt,_configuration.GetConnectionString("AsuPrint")));
            obj.AddSingleton<IConfigurationRoot>(_configuration);
            obj.AddTransient<services.NSI.INSI,services.NSI.NSI>();
            obj.AddTransient<services.ASPrint.IASPrint,services.ASPrint.ASPrintService>();
            obj.AddTransient<services.ServiceCompany.ISCService,services.ServiceCompany.SCService>();
            obj.AddTransient<services.ClickHouse.ICHSource,services.ClickHouse.CHSource>();
        }
    }
}
