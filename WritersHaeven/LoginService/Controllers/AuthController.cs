using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LoginService.Context;
///using LoginService.Migrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using LoginService.Models;
using Microsoft.EntityFrameworkCore.Update;
using LoginService.Auth;
using LoginService.Managers;

namespace LoginService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly MongoAccountManager _context;
        private readonly UserManager<Account> _accountManager;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;
        private readonly JsonSerializerSettings _serializerSettings;

        public AuthController(MongoAccountManager context, UserManager<Account> accountManager, IJwtFactory jwtFactory, JwtIssuerOptions jwtOptions, JsonSerializerSettings serializerSettings)
        {
            _context = context;
            _jwtFactory = jwtFactory;
            _accountManager = accountManager;
            _jwtOptions = jwtOptions;
            _serializerSettings = serializerSettings;
        }

        //POST: api/auth
 /*       [HttpPost("login")]
        public async Task<IActionResult> Login(AccountViewModel account) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var identity = await GetClaimsIdentity(account.Username, account.Password);
            if (identity == null)
            {
                return BadRequest(ModelState);
            }

            // Serialize and return the response
            var response = new
            {
                id = identity.Claims.Single(c => c.Type == "id").Value,
                auth_token = await _jwtFactory.GenerateEncodedToken(account.Username, identity),
                expires_in = (int)_jwtOptions.ValidFor.TotalSeconds,
                role = identity.Claims.Single(c => c.Type == "role").Value
            };

            var json = JsonConvert.SerializeObject(response, _serializerSettings);
            return new OkObjectResult(json);
        }

        private async Task<ClaimsIdentity> GetClaimsIdentity(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                // get the user to verifty
                var userToVerify = await _accountManager.FindByNameAsync(username);

                if (userToVerify != null)
                {
                    // check the credentials  
                    if (await _accountManager.CheckPasswordAsync(userToVerify, password))
                    {
                        Role role = _context.Roles.FirstOrDefault(r => r.IdentityId==Convert.ToInt32(userToVerify.UserId));
                        return await Task.FromResult(_jwtFactory.GenerateClaimsIdentity(username, userToVerify.UserId.ToString(), role.Name));



                    }
                }
            }

            // Credentials are invalid, or account doesn't exist
            return await Task.FromResult<ClaimsIdentity>(null);
        } */

    }



    
}
