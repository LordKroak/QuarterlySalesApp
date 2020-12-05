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
        public static string CheckEmployee(Repository<Employee> Data, Employee Employee)
        {
            string msg = " ";
            //check if employee already exists
            var options = new QueryOptions<Employee>
            {
                Where = c => c.FirstName.ToLower() == Employee.FirstName.ToLower()
                && c.LastName.ToLower() == Employee.LastName.ToLower()
                && c.DateOfBirth == Employee.DateOfBirth
            };
            var employee = Data.Get(options);
            if (employee != null)
            {
                return msg = $"Employee already exists.";
            }
            else
            {
                return msg = $"";
            }
        }
        public static string CheckManager(Repository<Employee> Data, Employee employee)
        {
            var manager = Data.Get(employee.ManagerID);
            string msg = " ";
            if(manager.FirstName.ToLower() == employee.FirstName.ToLower() && manager.LastName.ToLower() == employee.LastName.ToLower() && manager.DateOfBirth == employee.DateOfBirth && manager != null)
            {
                return msg = $"Employee cannot be their own manager.";
            }
            else
            {
                return msg = $"";
            }
        }
        public static string CheckSales(SalesUnitOfWork Data, Sales sales)
        {
            var options = new QueryOptions<Sales>
            {
                Where = s => s.EmployeeID == sales.EmployeeID
                && s.Year == sales.Year
                && s.Quarter == sales.Quarter
            };

            Sales sale = Data.Sales.Get(options);
            if (sale == null)
            {
                return string.Empty;
            }

            Employee employee = Data.Employees.Get(sales.EmployeeID);
            return $"Sales for {employee.FullName} for {sales.Year} Q{sales.Quarter} are already in the database.";
        }
    }
}
