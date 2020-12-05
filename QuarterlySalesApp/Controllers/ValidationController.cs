using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QuarterlySalesApp.Models;

namespace QuarterlySalesApp.Controllers
{
    public class ValidationController : Controller
    {
        private SalesUnitOfWork Data { get; set; } //get a copy of database context
        public ValidationController(SalesUnitOfWork data)
        {
            Data = data;
        }
        public JsonResult CheckEmployee(string firstname, string lastname, DateTime dateofbirth)
        {
            //this checks to see if the employee currently exists in the database
            var employee = new Employee
            {
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateofbirth
            };
            string msg = Validation.CheckEmployee(Data.Employees, employee); //checks database
            if (!string.IsNullOrEmpty(msg))
            {
                return Json($"Employee is already registered.");
            }
            else
            {
                return Json(true);
            }
        }

        public JsonResult CheckManager(string firstname,string lastname,DateTime dateofbirth, int managerid)
        {
            var manager = new Employee
            {
                FirstName = firstname,
                LastName = lastname,
                DateOfBirth = dateofbirth,
                ManagerID = managerid
            };
            string msg = Validation.CheckManager(Data.Employees, manager);
            if (!string.IsNullOrEmpty(msg))
            {
                return Json($"Employee can not be their own Manager.");
            }
            else
            {
                return Json(true);
            }
        }


        
    }
}
