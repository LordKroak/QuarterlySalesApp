using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class Employee
    {
        [Required(ErrorMessage = "Enter a first name.")]
        [Remote("CheckEmployee", "Validation", AdditionalFields = "LastName, DateofBirth")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]

        public DateTime DateOfBirth { get; set; }
        [Required]
        [Display(Name = "Date of Hire")]

        public DateTime DateOfHire { get; set; }
        [Required]
        public int ManagerID { get; set; }
        public int EmployeeID { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
