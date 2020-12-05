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
        public SalesUnitOfWork data { get; set; }
        public HomeController(EmployeeContext context)
        {
            data = new SalesUnitOfWork(context);
        }
        [HttpPost]
        public IActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new SalesGridBuilder(HttpContext.Session);
            if (clear)
            {
                builder.ClearFilterSegments();
            }
            else
            {
                var employee = data.Employees.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, employee);
            }
            builder.SaveRouteSegments();
            return RedirectToAction("Index", builder.CurrentRoute);
        }
        public IActionResult Index(SalesGridDTO id)
        {
            ViewModel view = new ViewModel(); //declares and instantiates a new copy of the class
            view.Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
            //filter through EmployeeID in SalesList (if EmployeeID)
            string defaultSortField = nameof(Sales.Year);
            SalesGridBuilder sales = new SalesGridBuilder(HttpContext.Session, id, defaultSortField);
            var options = new SalesQueryOptions
            {
                Includes = "Employee",
                OrderByDirection = sales.CurrentRoute.SortDirection,
                PageNumber = sales.CurrentRoute.PageNumber,
                PageSize = sales.CurrentRoute.PageSize
            };
            options.SortFilter(sales);
            view.SalesList = data.Sales.List(options);
            view.CurrentRoute = sales.CurrentRoute; //sets the value for CurrentRoute
            view.TotalPages = sales.GetTotalPages(data.Sales.Count);
            //IQueryable<Sales> sales = data.Sales; //gets list
            //if (id > 0) //if statement that filters out 0, 0 will show all employees and sales. Greater then 0 will return a specific employee
            //{
            //    sales = sales.Where(p => p.EmployeeID == id); //filters
            //}
            //view.SalesList = sales.ToList();  //this gives values to SalesList
            return View(view);
        }
    }
}
