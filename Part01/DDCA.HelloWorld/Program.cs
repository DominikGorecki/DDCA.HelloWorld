using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices;
using DDCA.HelloWorld.HelloWorldDomain;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DDCA.HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {

            /* 
             * Mock Presenter from Ch13 Part1 Step 1 (13.1.1)
            Console.WriteLine("Hello World");
            Console.Write("Please enter your name: ");
            var name = Console.ReadLine();
            Console.WriteLine($"Hi, {name}");
            Console.WriteLine("Presee any key to continue");
            Console.ReadKey();
            */
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton
                <IHelloWorldDomainService, 
                HelloWorldDomainService>();
            serviceCollection.AddTransient<App>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<App>().Run();
            
        }

        private class App
        {
            private readonly IHelloWorldDomainService _helloWorldService;

            public App(IHelloWorldDomainService helloWorldDS)
            {
                _helloWorldService = helloWorldDS ?? throw new ArgumentNullException(nameof(helloWorldDS));
            }

            public void Run()
            {
                Console.WriteLine(_helloWorldService.GetGreeting());
                Console.Write("Please enter your name: ");
                var name = Console.ReadLine();
                Console.WriteLine(_helloWorldService.GreetName(name));
                Console.WriteLine("Press any key to exit");
                Console.ReadKey();
            }
        }
    }
}
