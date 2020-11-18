using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
