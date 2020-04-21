using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices;
using System;

namespace DDCA.HelloWorld.HelloWorldDomain
{
    public class HelloWorldDomainService : IHelloWorldDomainService
    {
        public string GetGreeting() => "Hello World!";

        public string GreetName(string name) => $"Hi, {name}";
    }
}
