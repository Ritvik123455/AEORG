using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEORG
{
    public class ConfigurationManager
    {
        public static IConfigurationRoot Configuration { get; }

        static ConfigurationManager()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public static string ExePath => Configuration["Paths:ExePath"];
        public static string DefaultInputDirectory => Configuration["Paths:DefaultInputDirectory"];
        public static string DefaultDirectory => Configuration["Paths:DefaultDirectory"];
    }
}
