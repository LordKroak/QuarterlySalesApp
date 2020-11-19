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
        private EmployeeContext context;
        public ValidationController(EmployeeContext ctx) => context = ctx; //get a copy of database context
        public JsonResult CheckEmployee(string FirstName, string LastName, DateTime DateOfBirth)
        {
            //this checks to see if the employee currently exists in the database
            string msg = Validation.CheckEmployee(context, FirstName, LastName, DateOfBirth); //checks database
            if (!string.IsNullOrEmpty(msg))
            {
                return Json($"Employee is already registered.");
            }
            else
            {
                return Json(true);
            }
        }

        public JsonResult CheckManager(string FirstName,string LastName,DateTime DateOfBirth, int ManagerID)
        {
            string msg = Validation.CheckManager(context, FirstName, LastName, DateOfBirth, ManagerID);
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
