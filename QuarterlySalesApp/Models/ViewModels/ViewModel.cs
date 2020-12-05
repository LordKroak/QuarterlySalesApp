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
        public IEnumerable<Sales> SalesList { get; set; }
        public double TotalSales { get; set; } //holds TotalSales

        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<int> Years
        {
            get
            {
                List<int> YearsList = new List<int>(); //create new year list, where we will put years.
                for (int i = DateTime.Today.Year; i >= 1995; i--) //for loop goes through each integer 1995 - current year and adds it to the list.
                {
                    YearsList.Add(i);
                }
                return YearsList;
            }
        }

        public IEnumerable<int> Quarters 
        { 
            get
            {
                List<int> QuarterList = new List<int> { 1, 2, 3, 4 };
                return QuarterList;
            }
        }
        
    }
}
