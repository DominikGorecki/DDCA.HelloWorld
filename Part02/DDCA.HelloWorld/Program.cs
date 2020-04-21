using DDCA.helloWorld.Common.SeriLogService;
using DDCA.HelloWorld.Abstract.CommonServices.IServices;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices.SupportingApplication;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices.SupportingDomain;
using DDCA.HelloWorld.Common.NLogService;
using DDCA.HelloWorld.ConsoleApplication;
using DDCA.HelloWorld.Domain;
using DDCA.HelloWorld.Domain.Models;
using DDCA.HelloWorld.FileDataService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;

namespace DDCA.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<IHelloWorldDomainService, HelloWorldDomainService>();
            serviceCollection.AddTransient<IHelloWorldDataService, HelloWorldFileDataService>();
            //serviceCollection.AddTransient<IHelloWorldDataService, MockDataService>();
            //serviceCollection.AddTransient<ILogService, MockLogService>();
            //serviceCollection.AddTransient<ILogService, HelloWorldSeriLogService>();
            serviceCollection.AddTransient<ILogService, HelloWorldNLogService>();


            serviceCollection.Configure<HelloWorldConfig>(configuration.GetSection("HelloWorldConfiguration"));
            serviceCollection.AddTransient<IHelloWorldConsoleApp, HelloWorldConsoleApp>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<IHelloWorldConsoleApp>().Run();
        }

        private class MockLogService : ILogService
        {
            public void Log(string info) { }
        }

        // Use for 13.2.4
        private class MockDataService : IHelloWorldDataService
        {
            public IEnumerable<string> GetNames()
                => new string[] { "James", "Carolyn" };

            public void SaveNames(IEnumerable<string> newNames) { }
        }

    }
}
