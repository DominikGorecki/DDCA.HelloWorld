using System;
using System.Collections.Generic;
using System.Text;

namespace DDCA.HelloWorld.Abstract.HelloWorldDomain.IModels
{
    public interface IHelloWorldConfig
    {
        string GreetingMessage { get; }
        string GreetingNameMessage { get; }
    }
}
