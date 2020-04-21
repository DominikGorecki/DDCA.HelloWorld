using DDCA.HelloWorld.Abstract.CommonServices.IServices;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IModels;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices;
using DDCA.HelloWorld.Abstract.HelloWorldDomain.IServices.SupportingDomain;
using DDCA.HelloWorld.Domain.Models;
using Microsoft.Extensions.Options;
using System;

namespace DDCA.HelloWorld.Domain
{
    public class HelloWorldDomainService : IHelloWorldDomainService
    {
        private readonly HelloWorldConfig _configOptions;
        private readonly IHelloWorldDataService _dataService;
        private readonly HelloWorldNamesEntity _names;
        private readonly ILogService _logService;

        public HelloWorldDomainService(
            IOptionsSnapshot<HelloWorldConfig> optionsAccessor,
            IHelloWorldDataService dataService,
            ILogService logService)
        {
            _configOptions = optionsAccessor?.Value ?? throw new ArgumentNullException(nameof(optionsAccessor));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _names = new HelloWorldNamesEntity(_dataService.GetNames());
            _logService = logService ?? throw new ArgumentNullException(nameof(logService));
            _logService.Log($"{DateTime.Now.ToShortTimeString()} - Domain Service Initiated");
        }

        public string GetGreeting() => _configOptions.GreetingMessage;

        public IHelloWorldNames GetNamesEntity()
            => _names;

        public string GreetName(string name)
        {
            _names.AddName(name);
            return $"{_configOptions.GreetingNameMessage} {name}";
        }

        public void SaveNames()
            => _dataService.SaveNames(_names.AllNamesAphabetical);
    }
}
