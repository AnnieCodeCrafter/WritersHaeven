using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LoginService.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public int UserId { get; set; }

        public string Name { get; set; }
        public string PssWord { get; set; }

        public string Hello { get; set; }

        // public Account( string name, string pssword)
        // {
        //  
        //     this.Name = name;
        //     this.PssWord = pssword;
        // }
         
    }
}
