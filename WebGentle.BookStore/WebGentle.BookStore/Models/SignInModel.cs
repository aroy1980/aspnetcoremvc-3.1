using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Please Enter Your Email ID"),EmailAddress]
        [Display(Name ="Email/UserID")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
