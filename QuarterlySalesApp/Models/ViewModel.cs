using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class ViewModel
    {
        //List of Employees
        //List of Sales
        //Total Sales
        public int EmployeeID { get; set; }
        public List<Employee> EmployeeList { get; set; }

        public List<Sales> SalesList { get; set; }
        public double TotalSales { get; set; } //holds TotalSales
    }
}
