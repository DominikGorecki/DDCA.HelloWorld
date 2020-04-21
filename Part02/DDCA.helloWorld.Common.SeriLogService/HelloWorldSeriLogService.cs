using DDCA.HelloWorld.Abstract.CommonServices.IServices;
using Serilog;
using System;

namespace DDCA.helloWorld.Common.SeriLogService
{
    public class HelloWorldSeriLogService : ILogService
    {
        public HelloWorldSeriLogService()
        {
            //Need to use Serilog namespace because of conflict with ILogService
            Serilog.Log.Logger = new Serilog.LoggerConfiguration()
                .WriteTo.File("log.txt", rollingInterval: Serilog.RollingInterval.Day)
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .CreateLogger();
        }

        public void Log(string info)
        {
            Serilog.Log.Information(info);
        }
    }
}
