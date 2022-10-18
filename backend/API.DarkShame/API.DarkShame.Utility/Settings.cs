using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.DarkShame.Utility
{
    internal class Settings
    {
        private readonly IConfiguration configuration;

        public IConfiguration Configuration
        {
            get { return this.configuration; }
        }

        internal Settings()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (string.IsNullOrWhiteSpace(env))
                throw new ArgumentException("ASPNETCORE_ENVIRONMENT environment variable is not set");

            try
            {
                var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", optional: true, reloadOnChange: false).AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: false).AddEnvironmentVariables();
                this.configuration = builder.Build();
            }
            catch (FormatException e)
            {
                throw new FormatException("Configuration files not configured correctly! Check the.json file format", e);
            }
            catch (Exception ex)
            {
                throw new Exception("Error loading configuration files", ex);
            }
        }
    }
}
