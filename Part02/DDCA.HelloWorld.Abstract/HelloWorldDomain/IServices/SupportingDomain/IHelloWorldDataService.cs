using System;
using System.Collections.Generic;
using System.Text;

namespace DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices.SupportingDomain
{
    public interface IHelloWorldDataService
    {
        IEnumerable<string> GetNames();
        void SaveNames(IEnumerable<string> newNames);
    }
}
