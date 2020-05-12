using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //
        //     optionsBuilder.UseSqlServer(
        //         @"Server = mssql.fhict.local; Database = dbi364679_hvnaccount; User Id = dbi364679; Password = Haeven2020;");
        // }

     
        public Microsoft.EntityFrameworkCore.DbSet<Account> Accounts { get; set; }
    }
}
