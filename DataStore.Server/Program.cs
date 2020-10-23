using DataStore.Server.Interfaces;
using Microsoft.AspNetCore.Hosting;
using SoapCore;
using System;
using System.Configuration;
using System.IO;
using System.ServiceModel; 
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DataStore.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new WebHostBuilder()
              .UseKestrel()
              .UseUrls(ConfigurationManager.AppSettings["BaseAddress"])
              .UseContentRoot(Directory.GetCurrentDirectory())
              .Configure((app) =>
              {
                  Console.WriteLine("Configuring the Service");
                  app.UseSoapEndpoint<IOperations>("/FileStoreService.svc", new BasicHttpBinding(), SoapSerializer.XmlSerializer);
              })
              .ConfigureServices((services) =>
              {
                  services.TryAddSingleton<IOperations, FileStore.FileOperations>();

              })
              .Build();

            host.Run();
        }
    }
}
