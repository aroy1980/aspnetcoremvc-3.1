using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Models
{
    public class ChangePasswordModel
    {
        [Required(ErrorMessage ="Enter Old Password"),DataType(DataType.Password), Display(Name ="Current Passwod")]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Enter New Password"), DataType(DataType.Password), Display(Name = "New Passwod")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Enter New Password Again"), DataType(DataType.Password), Display(Name = "Confirm Passwod")]
        [Compare("NewPassword",ErrorMessage ="Password is Mismatched")]
        public string ConfirmPassword { get; set; }
    }
}
