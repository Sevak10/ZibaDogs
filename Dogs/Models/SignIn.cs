using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dogs.Models
{
    public class SignIn
    {
        [Required(ErrorMessage = "Please enter your Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid Email address")]
        public string Email { get; set; }
        [RegularExpression("[^ 0 - 9]", ErrorMessage = "Please enter valid phone")]
        [Required(ErrorMessage = "Please enter your ID")]
        public int Phone { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Password")]
        public string Text { get; set; }
        public byte[] PhotoData { get; set; }
    }
}
