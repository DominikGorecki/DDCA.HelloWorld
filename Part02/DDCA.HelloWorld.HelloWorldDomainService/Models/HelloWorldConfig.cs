using DDCA.HelloWorld.Abstract.HelloWorldDomain.IModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDCA.HelloWorld.Domain.Models
{
    public class HelloWorldConfig : IHelloWorldConfig
    {
        public HelloWorldConfig()
        {
            GreetingMessage = "Hello World!";
            GreetingNameMessage = "Hi,";

        }
        public string GreetingMessage { get; set; } 

        public string GreetingNameMessage { get; set; } 
    }
}
