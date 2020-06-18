using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class AccountViewModel
    {

        public string UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public AccountViewModel()
        {

        }

        public AccountViewModel(string email, string password, string username, string role)
        {
            Email = email;
            Password = password;
            Username = username;            
            Role = role;
        }

    }
}
