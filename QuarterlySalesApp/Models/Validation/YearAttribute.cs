using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class YearAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid (object value, ValidationContext ctx)
        {
            if (value is int)
            {
                int yearToCheck = (int)value;
                if (yearToCheck > 2000)
                {
                    return ValidationResult.Success;
                }
            }
            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be after the year 2000.";
            return new ValidationResult(msg);
        }
    }
}
