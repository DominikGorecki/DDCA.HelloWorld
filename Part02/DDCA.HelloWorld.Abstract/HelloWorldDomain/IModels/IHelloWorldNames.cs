using System;
using System.Collections.Generic;
using System.Text;

namespace DDCA.HelloWorld.Abstract.HelloWorldDomain.IModels
{
    public interface IHelloWorldNames
    {
        IEnumerable<string> ExistingNames { get; }
        IEnumerable<string> NewNames { get; }
        IEnumerable<string> AllNamesAphabetical { get; }
        IEnumerable<string> NewNamesAlphabetical { get; }
    }
}
