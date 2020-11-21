using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QuarterlySalesApp.Models
{
    public class PastDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid (object value, ValidationContext ctx)
        {
            if (value is DateTime)
            {
                DateTime dateToCheck = (DateTime)value;
                if (dateToCheck < DateTime.Today)
                {
                    return ValidationResult.Success;
                }
            }
            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be a valid date in the past.";
            return new ValidationResult(msg);
        }
    }
}
