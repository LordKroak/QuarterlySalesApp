using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuarterlySalesApp.Models;

namespace QuarterlySalesApp.Controllers
{
    public class HomeController : Controller
    {
        public EmployeeContext Context { get; set; }
        public HomeController(EmployeeContext context) //parameter accepts employeecontext variable
        {
            //set property equal to the value passed
            Context = context;
        }

        public IActionResult Index(int id)
        {
            ViewModel view = new ViewModel(); //declares and instantiates a new copy of the class
            view.EmployeeList = Context.Employees.ToList();
            //filter through EmployeeID in SalesList (if EmployeeID)
            List<Sales> sales = Context.Sales //gets list
                .Where(p => p.EmployeeID == id).ToList(); //filters
            view.SalesList = sales;  //this gives values to SalesList
            return View(view);
        }
    }
}
