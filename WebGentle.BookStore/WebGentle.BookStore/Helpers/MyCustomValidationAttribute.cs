using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebGentle.BookStore.Helpers
{
    public class MyCustomValidationAttribute : ValidationAttribute
    {
        public string Text { get; set; }
        public string MyProperty { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string BookName = value.ToString();
                if(BookName.Contains(Text))
                {
                    return ValidationResult.Success;
                }
            }
           

                return new ValidationResult(ErrorMessage?? "Book Does Not Contain the Desired Value");
        }
    }
}
