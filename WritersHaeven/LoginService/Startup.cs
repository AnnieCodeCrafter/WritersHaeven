using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Auth;
using LoginService.Context;
using LoginService.Managers;
using LoginService.Models;
using LoginService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace LoginService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<AccountContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:AccountDB"]));
            // services.AddScoped<IDataRepository<Account>, AccountManager>();

     /*       services.AddScoped<IJwtFactory, JwtFactory>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("admin", policy => policy.RequireClaim(Helpers.Constants.Strings.JwtClaimIdentifiers.Role, Helpers.Constants.Strings.JwtClaims.AdminAccess));
                options.AddPolicy("user", policy => policy.RequireClaim(Helpers.Constants.Strings.JwtClaimIdentifiers.Role, Helpers.Constants.Strings.JwtClaims.UserAccess));

            });*/

            services.Configure<AccountDatabaseSettings>(
       Configuration.GetSection(nameof(AccountDatabaseSettings)));

             services.AddSingleton<IAccountDbSettings>(sp =>
               sp.GetRequiredService<IOptions<AccountDatabaseSettings>>().Value);
            services.AddSingleton<MongoAccountManager>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
