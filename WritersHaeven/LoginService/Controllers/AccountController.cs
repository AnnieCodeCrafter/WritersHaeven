using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoginService.Context;
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
        private readonly AccountContext _context;

        public AccountController(AccountContext context)
        {
            _context = context;
        }


        //GET: api/account
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> getAccounts()
        {
            
                return await _context.Accounts.ToListAsync();
                
        }

        //POST: api/account
        [HttpPost]
        public async Task<ActionResult<Account>> postAccount(Account account)
        {
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new {id = account.UserId}, account);
        }

        //GET: api/account/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }

            return account;
        }

        



    }
}