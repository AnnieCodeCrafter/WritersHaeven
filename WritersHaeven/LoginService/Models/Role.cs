using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginService.Models
{
    public class Role
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }

        public int IdentityId { get; set; }


        public string Name { get; set; }
    }
}
