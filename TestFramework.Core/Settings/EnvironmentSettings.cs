using Microsoft.Extensions.Configuration;
using System;

namespace TestFramework.Core.Settings
{
    public static class EnvironmentSettings
    {
        private static string _currentBrowser;
        public static string CurrentBrowser
        {
            get
            {
                return _currentBrowser;
            }
            set
            {
                if (_currentBrowser == null)
                    _currentBrowser = value;
            }
        }
        private static string _currentConfiguration;
        public static string CurrentConfiguration
        {
            get
            {
                return _currentConfiguration;
            }
            set
            {
                if (_currentConfiguration == null)
                {
                    switch (value)
                    {
                        case "dev":
                            _currentConfiguration = Configurations.DevConfig;
                            break;
                        case "qa":
                            _currentConfiguration = Configurations.QAConfig;
                            break;
                        default: _currentConfiguration = Configurations.DevConfig;
                            break;
                    }
                }
            }
        }
        public static IConfiguration GetConfiguration() => new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(_currentConfiguration)
            .Build();
        internal static class Configurations
        {
            public const string DevConfig = "dev.config.json";
            public const string QAConfig = "qa.config.json";
        }
    }
}