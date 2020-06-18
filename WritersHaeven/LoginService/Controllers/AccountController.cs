using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Context;
using LoginService.Managers;
using LoginService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MongoAccountManager _context;

        public AccountController(MongoAccountManager context)
        {
            _context = context;
        }


        //GET: api/account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> getAccounts()
        {

            return await Task.FromResult(_context.Get());
                
        }

        //POST: api/account
        [HttpPost]
        public async Task<ActionResult<Account>> postAccount(Account account)
        {
            _context.Create(account);
            

            return await Task.FromResult(CreatedAtAction("GetAccount", new {id = account.UserId}, account));
        }

        //GET: api/account/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await Task.FromResult(_context.Get(id));

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

      

        



    }
}