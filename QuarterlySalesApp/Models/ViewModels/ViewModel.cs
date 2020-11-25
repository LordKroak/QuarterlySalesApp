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

        public IEnumerable<Sales> SalesList { get; set; }
        public double TotalSales { get; set; } //holds TotalSales

        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<int> Years { get; set; }
        public IEnumerable<int> Quarters { get; set; }
        
    }
}
