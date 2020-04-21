using DDCA.HelloWorld.Abstract.CommonServices.IServices;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices.SupportingDomain;
using System;
using System.Collections.Generic;
using System.IO;

namespace DDCA.HelloWorld.FileDataService
{
    public class HelloWorldFileDataService : IHelloWorldDataService
    {
        private readonly ILogService _logService;

        public HelloWorldFileDataService(ILogService logService)
        {
            _logService = logService ?? throw new ArgumentNullException(nameof(logService));
            _logService.Log("Data Service Started");
        }

        public IEnumerable<string> GetNames()
        {
            if (!File.Exists("data.txt"))
                return null;

            _logService.Log("Data Service Call - GetNames");

            return File.ReadAllLines("data.txt");
        }

        public void SaveNames(IEnumerable<string> newNames)
        {
            _logService.Log("Data Service Call - SaveNames");
            File.WriteAllLines("data.txt", newNames);
        }
    }
}
