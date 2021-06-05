using Library.DAL.Constants;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await InitializeDatabase(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static async Task InitializeDatabase(IHost host)
        {
            if (host == null)
                throw new ArgumentNullException(nameof(host));

            using var serviceScope = host.Services.GetService<IServiceScopeFactory>().CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
            string[] roleNames = { Role.Admin, Role.Basic };
            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var isRoleExisting = await roleManager.RoleExistsAsync(role);
                if (!isRoleExisting)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole<Guid>(role));
                }
            }
        }
    }
}
