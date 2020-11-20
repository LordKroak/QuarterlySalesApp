using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuarterlySalesApp.Models;

namespace QuarterlySalesApp.Models
{
    public class Validation
    {
        public static string CheckEmployee(EmployeeContext ctx, string FirstName, string LastName, DateTime DateOfBirth)
        {
            string msg = " ";
            //check if employee already exists
            var employee = ctx.Employees.FirstOrDefault(
                c => c.FirstName.ToLower() == FirstName.ToLower()
                && c.LastName.ToLower() == LastName.ToLower()
                && c.DateOfBirth == DateOfBirth); 
            if (employee != null)
            {
                return msg = $"Employee already exists.";
            }
            else
            {
                return msg = $"";
            }
        }
        public static string CheckManager(EmployeeContext ctx, string FirstName, string LastName, DateTime DateOfBirth, int ManagerID)
        {
            string msg = " ";
            var manager = ctx.Employees.FirstOrDefault(
                c => c.EmployeeID == ManagerID
                );
            if(manager.FirstName.ToLower() == FirstName.ToLower() && manager.LastName.ToLower() == LastName.ToLower() && manager.DateOfBirth == DateOfBirth)
            {
                return msg = $"Employee cannot be their own manager.";
            }
            else
            {
                return msg = $"";
            }
        }
        public static string CheckSales(EmployeeContext ctx, Sales sales)
        {
            Sales sale = ctx.Sales.FirstOrDefault(
                s => s.EmployeeID == sales.EmployeeID
                && s.Year == sales.Year
                && s.Quarter == sales.Quarter);

            if (sale == null)
            {
                return string.Empty;
            }

            Employee employee = ctx.Employees.Find(sales.EmployeeID);
            return $"Sales for {employee.FullName} for {sales.Year} Q{sales.Quarter} are alread in the database.";
        }
    }
}
