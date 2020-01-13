using NUnitLite;
using System;
using System.IO;
using System.Reflection;
using TestFramework.Core.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Start working...");
            EnvironmentSettings.CurrentBrowser = args[0];
            EnvironmentSettings.CurrentConfiguration = args[1];
            var testRunner = new AutoRun(Assembly.GetExecutingAssembly());
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            string[] test;
            try
            {
                 test = new string[] { $"--testlist:{Directory.GetCurrentDirectory()}//{args[2]}" };
            }
            catch (Exception ex)
            {
                 test = new string[] { $"--testlist:{Directory.GetCurrentDirectory()}\\{args[2]}" };
            }
            testRunner.Execute(test);

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole())
                    .AddSingleton<Tests.Source.Tests>();
        }
    }
}