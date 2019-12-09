using NUnitLite;
using System;
using System.Reflection;
using TestFramework.Core.Settings;

namespace TestFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: get strings args by keys instead array index
            Console.WriteLine("Start working...");
            EnvironmentSettings.CurrentBrowser = args[0];
            EnvironmentSettings.CurrentConfiguration = args[1];
            var testRunner = new AutoRun(Assembly.GetExecutingAssembly());
            //TODO: expire with docs https://github.com/nunit/docs/wiki/Console-Command-Line
            string[] test = new string[] { "--test:TestFramework.Tests.Source.Tests.CheckComparisonProduct" };
            testRunner.Execute(test);
            
        }
    }
}