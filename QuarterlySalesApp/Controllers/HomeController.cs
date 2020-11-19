﻿using System;
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
        [HttpPost]
        public IActionResult Index(Employee Employee)
        {
            //look to see if it is 0 or not
            //if it is 0 show everything, otherwise show specific employee
            if (Employee.EmployeeID > 0)
            {
                return RedirectToAction("Index", new{id = Employee.EmployeeID});
            }
            return RedirectToAction("Index", new { id = 0 });
        }
        public IActionResult Index(int id)
        {
            ViewModel view = new ViewModel(); //declares and instantiates a new copy of the class
            view.EmployeeList = Context.Employees.ToList();
            //filter through EmployeeID in SalesList (if EmployeeID)
            IQueryable<Sales> sales = Context.Sales; //gets list
            if (id > 0) //if statement that filters out 0, 0 will show all employees and sales. Greater then 0 will return a specific employee
            {
                sales = sales.Where(p => p.EmployeeID == id); //filters
            }
            view.SalesList = sales.ToList();  //this gives values to SalesList
            return View(view);
        }
    }
}
