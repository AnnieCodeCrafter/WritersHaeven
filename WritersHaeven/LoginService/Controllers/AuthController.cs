using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LoginService.Context;
///using LoginService.Migrations;
using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;
using LoginService.Models;
using Microsoft.EntityFrameworkCore.Update;
using LoginService.Auth;
using LoginService.Managers;
using System.Configuration;
using MongoDB.Bson;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MongoAccountManager _context;
        //  private readonly UserManager<Account> _accountManager;
        /*   private readonly IJwtFactory _jwtFactory;
           private readonly JwtIssuerOptions _jwtOptions;
           private readonly JsonSerializerSettings _serializerSettings; */

        public AuthController(MongoAccountManager context)
        {
            _context = context;
            /*  _jwtFactory = jwtFactory;
              //_accountManager = accountManager;
              _jwtOptions = jwtOptions;
              _serializerSettings = serializerSettings;*/
        }




        //POST: api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(AccountViewModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Account userToVerify = await Task.FromResult(_context.Get(account.Username));
            if (userToVerify != null && userToVerify.PssWord == account.Password)
            {
                return new OkObjectResult("You have been logged in.");
            }


            return NotFound();

        }

       //api/auth/register
        [HttpPost("register")]
        public async Task<IActionResult> Account([FromBody]Account account)
        {
            //check if valid
            if (!ModelState.IsValid && account != null)
            {
                return BadRequest(ModelState);
            }

            //check if username already exists
            Account userToVerify = await Task.FromResult(_context.Get(account.Name));
            if(userToVerify == null)
            {
                await Task.FromResult(_context.Create(account));
                return new OkObjectResult("Account created");
            }

            return NotFound();

        }


        //api/auth get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> getAuthAccount()
        {

            return await Task.FromResult(_context.Get());

        }


        /*     private async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
             {
                 if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                 {
                     // get the user to verifty
                     Account userToVerify = await Task.FromResult(_context.Get(username));

                     if (userToVerify != null)
                     {
                         // check the credentials  
                         if (await Task.FromResult(CheckPassword(userToVerify, password)))
                         {

                      //return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(username, userToVerify.UserId.ToString(), true));

                         ]

                         }
                     }
                 }

                 // Credentials are invalid, or account doesn't exist
                 return await Task.FromResult<ClaimsIdentity>(null);
             }*/




    }




}
