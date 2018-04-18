using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using StudentsManagement.Authentication;
using StudentsManagement.Core.Shared;

namespace StudentActivityMenagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            var scope = host.Services.CreateScope();
            var serviceProvider = scope.ServiceProvider;

            var authInitService = serviceProvider.GetRequiredService<IAuthenticationInitializeService>();

            authInitService.Initialize();

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
