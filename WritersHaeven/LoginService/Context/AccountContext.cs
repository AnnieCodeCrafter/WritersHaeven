using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Devart.Data.Oracle;
using LoginService.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace LoginService.Context
{
    public class AccountContext : DbContext
    
    {
        public AccountContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder model)
        {
           /* model.Entity<Account>().HasData(new Account
            {
                UserId = 1,
                Name = "boo",
                PssWord = "beep"
            }, new Account
            {
                UserId = 2,
                Name = "blep",
                PssWord = "bleep"
            });
        

            model.Entity<Role>().HasData(new Role
            {
                RoleId = 1,
              IdentityId = 1,              
               Name = "Admin"

           }, new Role
            {
               RoleId = 2,
               IdentityId = 2,
               Name = "User"


           });*/
        }

       



        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //
        //     optionsBuilder.UseSqlServer(
        //         @"Server = mssql.fhict.local; Database = dbi364679_hvnaccount; User Id = dbi364679; Password = Haeven2020;");
        // }

       
     
        public Microsoft.EntityFrameworkCore.DbSet<Account> Accounts { get; set; }
    }
}
