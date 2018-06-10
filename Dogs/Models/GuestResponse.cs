using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data;

namespace Dogs.Models
{
    
    public class GuestResponse 
    {
        [Required(ErrorMessage = "Please enter your Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid Email address")]
        public string Email { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
        public string UserName { get; set; }
        public string DogName { get; set; }
        public int EmailCod { get; set; }
        public int EmailCod2 { get; set; }
    }
}
