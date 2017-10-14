﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace bimp.web.map
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddEnvironmentVariables("").Build();
            var url = config["ASPNETCORE_URLS"] ?? "http://*:8080";
            BuildWebHost(args,url).Run();
        }

        public static IWebHost BuildWebHost(string[] args, string url) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())                
                .UseStartup<Startup>()
                .UseUrls(url)
                .UseIISIntegration()
                .Build();
    }
}
