using DDCA.HelloWorld.Abstract.HelloWorldDomain.IModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDCA.HelloWorld.Domain
{
    public class HelloWorldNamesEntity : IHelloWorldNames
    {
        public HelloWorldNamesEntity(IEnumerable<string> existingNames)
        {
            ExistingNames = existingNames ?? new List<string>();
            NewNames = new List<string>();
        }

        public void AddName(string name)
            => NewNames = NewNames.Concat(new[] { name });

        public IEnumerable<string> ExistingNames { get; private set; }

        public IEnumerable<string> NewNames { get; private set; }

        public IEnumerable<string> AllNamesAphabetical =>
            ExistingNames.Concat(NewNames).OrderBy(n => n).ToList();

        public IEnumerable<string> NewNamesAlphabetical => NewNames.OrderBy(n => n).ToList();
    }
}
