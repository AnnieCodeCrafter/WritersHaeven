using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Context;
using LoginService.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LoginService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            
            //
            // using (var ctx = new AccountContext())
            // {
            //     string testName = DateTime.Now.ToLongDateString();
            //
            //     var acct = new Account("writery " + testName, "writery");
            //
            //     ctx.Accounts.Add(acct);
            //     ctx.SaveChanges();
            // }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
