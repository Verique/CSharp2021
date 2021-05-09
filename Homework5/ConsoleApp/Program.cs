using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StringToInt;
using NLog;
using NLog.Extensions.Logging;
using ILogger = Microsoft.Extensions.Logging.ILogger;
using LogLevel = NLog.LogLevel;

namespace ConsoleApp
{
    internal class Program
    { 
        public static void Main(string[] args)
        {
            ConfigureLogger();
            StringToInt.LoggerWrapper.MyLogger = GetILogger();
            
            Console.Write("Enter an integer : ");
            var input = Console.ReadLine();
            
            try
            {
                var intValue = input.ToInt();
                Console.WriteLine($"Your integer : {intValue}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"{input} is wrong argument. {e.Message}");
            }
        }

        private static void ConfigureLogger()
        {
            var config = new NLog.Config.LoggingConfiguration();
            var errorFile = new NLog.Targets.FileTarget("errorFile") {FileName = "errorLog.log"};
            var logFile = new NLog.Targets.FileTarget("logFile") {FileName = "log.log"};
            
            config.AddRule(LogLevel.Error, LogLevel.Fatal, errorFile);
            config.AddRule(LogLevel.Debug, LogLevel.Warn, logFile);

            NLog.LogManager.Configuration = config;
        }

        private static ILogger GetILogger()
        {
            var services = new ServiceCollection();
            services.AddLogging(builder => builder.AddNLog(NLog.LogManager.Configuration));
            var provider = services.BuildServiceProvider();
            return provider.GetService<ILogger<Program>>();
        }
    }
}