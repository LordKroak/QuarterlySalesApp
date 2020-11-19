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

        public static string CheckSales(EmployeeContext context, Sales sale)
        {
            string msg = " ";
            Sales Sales = context.Sales.FirstOrDefault(
                c => c.EmployeeID == sale.EmployeeID
                && c.Year == sale.Year
                && c.Quarter == sale.Quarter);

            if(Sales == null)
            {
                return string.Empty;
            }

            Employee employee = context.Employees.Find(sale.EmployeeID);
            return msg = $"Sales for {employee.FullName} for {sale.Year} Q{sale.Quarter} are alread in the database.";
        }
    }
}
