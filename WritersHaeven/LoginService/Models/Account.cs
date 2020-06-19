using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Threading.Tasks;
using MongoDB.Driver.Core.Authentication;

namespace LoginService.Models
{
    [BsonIgnoreExtraElements]
    public class Account
    {
      //  [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [BsonId]
       public ObjectId UserId { get; set; }

        [BsonElement("Username")]
        public string Name { get; set; }
        [BsonElement("Password")]
        public string PssWord { get; set; }


        // public Account( string name, string pssword)
        //{

        //     this.Name = name;
        //     this.PssWord = pssword;
        // }


        public override string ToString()
        {
            return UserId + "," + Name + "," + PssWord;
        }

        
    }
}
