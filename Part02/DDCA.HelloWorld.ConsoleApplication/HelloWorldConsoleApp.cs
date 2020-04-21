using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices.SupportingApplication;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DDCA.HelloWorld.ConsoleApplication
{
    public class HelloWorldConsoleApp : IHelloWorldConsoleApp
    {
        private readonly IHelloWorldDomainService _helloWorldService;

        public HelloWorldConsoleApp(IHelloWorldDomainService helloWorldDS)
        {
            _helloWorldService = helloWorldDS ?? throw new ArgumentNullException(nameof(helloWorldDS));
        }

        public void Run()
        {
            Console.WriteLine(_helloWorldService.GetGreeting());
            var exitApp = false;
            while(!exitApp)
            {
                Console.Write("Please enter your name: ");
                var name = Console.ReadLine();

                switch(name)
                {
                    case "wq":
                        exitApp = true;
                        _helloWorldService.SaveNames();
                        break;
                    case "q!":
                        exitApp = true;
                        break;
                    case "ls":
                        DisplayNames(_helloWorldService.GetNamesEntity().AllNamesAphabetical);
                        break;
                    case "ls-new":
                        DisplayNames(_helloWorldService.GetNamesEntity().NewNames);
                        break;
                    default:
                        Console.WriteLine(_helloWorldService.GreetName(name));
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                           
                }
                Console.Clear();

            } 

            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private void DisplayNames(IEnumerable<string> names)
        {
            Console.Clear();
            names.ToList().ForEach(n =>
            {
                Console.WriteLine(n);
            });
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
