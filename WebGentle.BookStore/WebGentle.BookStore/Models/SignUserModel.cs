using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Models
{
    public class SignUserModel
    {
        [Required(ErrorMessage ="Please Enter FirstName")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter last Name")]
        [Display(Name = "Last Name")]
        public string  LastName { get; set; }
        //[Required(ErrorMessage = "Please Enter Date of Birth")]
        //[Display(Name = "Date Of Birth")]
        //[DataType(DataType.Date)]
        //public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage ="Please Enter Your E-mail")]
        [Display(Name ="E-mail Address")]
        [EmailAddress(ErrorMessage ="Enter a valid E-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [Compare("ConfirmPassword", ErrorMessage ="Password Does Not Match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Confirm Your Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
