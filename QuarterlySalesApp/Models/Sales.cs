using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class Sales
    {
        [Required(ErrorMessage = "Please enter a quarter 1-4.")]
        [Range(1, 4)]
        public int? Quarter { get; set; }
        [Required(ErrorMessage = "Please enter a year.")]
        public int Year { get; set; } //create data attribute
        [Required(ErrorMessage = "Please enter a valid sales amount.")]
        [Range(1, 99999999999999999)]
        public double? SalesAmount { get; set; } //create data attribute
        public int SalesID { get; set; } // to hold pkey
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; } // to  hold pkey
        //to hold navigation to employee class
        public Employee Employee { get; set; }
        
    }
}
