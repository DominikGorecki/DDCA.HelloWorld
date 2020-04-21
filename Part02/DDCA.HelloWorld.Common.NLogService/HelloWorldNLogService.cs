using DDCA.HelloWorld.Abstract.CommonServices.IServices;
using NLog;
using System;

namespace DDCA.HelloWorld.Common.NLogService
{
    public class HelloWorldNLogService : ILogService
    {
        private readonly NLog.Logger _nLogger = NLog.LogManager.GetCurrentClassLogger();
        public HelloWorldNLogService()
        {
            var config = new NLog.Config.LoggingConfiguration();

            // Targets where to log to: File and Console
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "nlog.txt" };
            //var logconsole = new NLog.Targets.ConsoleTarget("logconsole");

            // Rules for mapping loggers to targets            
            // config.AddRule(NLog.LogLevel.Info, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);

            NLog.LogManager.Configuration = config;
        }
        public void Log(string info)
        {
            _nLogger.Info(info);
        }
    }
}
