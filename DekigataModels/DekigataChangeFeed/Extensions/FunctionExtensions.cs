using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DekigataChangeFeed
{
    internal static class FunctionExtensions
    {
        public static IConfiguration GetConfiguration(this ExecutionContext context)
        {
            return new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }
    }
}
