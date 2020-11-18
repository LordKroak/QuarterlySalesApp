using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class SalesAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid (object value, ValidationContext ctx)
        {
            if (value is int)
            {
                int amountToCheck = (int)value;
                if (amountToCheck > 0)
                {
                    return ValidationResult.Success;
                }
            }
            string msg = base.ErrorMessage ?? $"{ctx.DisplayName} must be greater then $0.";
                return new ValidationResult(msg);
        }
    }
}
