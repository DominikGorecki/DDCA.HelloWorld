﻿using DDCA.HelloWorld.Abstract.HelloWorldDomain.IModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices
{
    public interface IHelloWorldDomainService
    {
        string GetGreeting();
        string GreetName(string name);
        IHelloWorldNames GetNamesEntity();
        void SaveNames();
    }
}
