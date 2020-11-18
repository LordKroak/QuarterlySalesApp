using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class PostDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid (object value, ValidationContext ctx)
        {
            if (value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;

                if (dateToCheck > new DateTime(1995, 1, 1))
                {
                    return ValidationResult.Success;
                }
            }
            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be a valid date after 01/01/1995.";
            return new ValidationResult(msg);
        }
    }
}
