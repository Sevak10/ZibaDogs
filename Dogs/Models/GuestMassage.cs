using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dogs.Models
{
    public class GuestMassage
    {
        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter your Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid Email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter your Number")]
        [RegularExpression("[^ 0 - 9]",ErrorMessage = "Please enter valid phone")]
        public string Phone { get; set; }
        [RegularExpression("[^ 0 - 9]", ErrorMessage = "Please enter valid phone")]
        [Required(ErrorMessage = "Please enter your ID")]
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter your Subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please enter Massage")]
        public string Massage { get; set; }
    }
}
