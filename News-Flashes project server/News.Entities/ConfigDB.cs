﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace News.Entities
{
    public class ConfigDB
    {
        public static string GetConfigConnectionString()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            string connectionString = config.GetConnectionString("MyDB");

            return connectionString;
        }

    }
}
