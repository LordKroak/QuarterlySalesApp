using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using QuarterlySalesApp.Models;
using Microsoft.EntityFrameworkCore;

namespace QuarterlySalesApp.Controllers
{
    public class SalesController : Controller
    {
        public SalesUnitOfWork data { get; set; }
        public SalesController(EmployeeContext context)
        {
            data = new SalesUnitOfWork(context);
        }
        [HttpPost]
        public IActionResult Add(Sales Sales)
        {
            string msg = Validation.CheckSales(data, Sales); //checks database
            if (!string.IsNullOrEmpty(msg))
            {
                ModelState.AddModelError(nameof(Sales.EmployeeID), msg);
            }
            //do the same thing for checking the manager
            //code will be the same thing except call other validation function
            if (ModelState.IsValid)
            {
                data.Sales.Insert(Sales); //adds it to entity framework
                data.Save(); //saves it to the database
                TempData["msg"] = "Sale was added.";
                return RedirectToAction("Index", "Home"); //takes us back to the page
            }
            else //if there is a validation error, pass a list of the employees
            {
                ViewBag.Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName }) ;
                return View();
            }
        }
        public IActionResult Add()
        {
            //populate viewbag sales with a list of sales
            ViewBag.Employees = data.Employees.List(new QueryOptions<Employee> { OrderBy = e => e.FirstName });
            return View();
        }

        //public ViewResult List(SalesGridDTO values)
        //{
        //    var builder = new SalesGridBuilder(HttpContext.Session, values, defaultSortField: nameof(Sales.Year));

        //    var options = new QueryOptions
        //    {
        //        Include = "Employee.FullName, Year, Quarter, SalesAmount",
        //        OrderByDirection = builder.CurrentRoute.SortDirection,
        //        PageNumber = builder.CurrentRoute.PageNumber,
        //        PageSize = builder.CurrentRoute.PageSize
        //    };
        //    options.SortFilter(builder);

        //    var vm = new ViewModel
        //    {
        //        SalesList = data.Sales.List(options),
        //        Employees = data.Employees.List(new QueryOptions<Employee>
        //        {
        //            OrderBy = a => a.FirstName
        //        }),
        //        CurrentRoute = builder.CurrentRoute,
        //        TotalPages = builder.GetTotalPages(data.Sales.Count)
        //    };
        //    return View(vm);
        //}
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
        //[HttpPost]
        //public RedirectToActionResult Filter(string[] filter, bool clear = false)
        //{
        //    var builder = new SalesGridBuilder(HttpContext.Session);

        //    if (clear)
        //    {
        //        builder.ClearFilterSegments();
        //    }
        //    else
        //    {
        //        var author = data.Employees.Get(filter[0].ToInt());
        //        builder.CurrentRoute.PageNumber = 1;
        //        builder.LoadFilterSegments(filter, employee);
        //    }
        //    builder.SaveRouteSegments();
        //    return RedirectToAction("List", builder.CurrentRoute);
        //}
        //[HttpPost]
        //public RedirectToActionResult PageSize(int pagesize)
        //{
        //    var builder = new SalesGridBuilder(HttpContext.Session);

        //    builder.CurrentRoute.PageSize = pagesize;
        //    builder.SaveRouteSegments();

        //    return RedirectToAction("List", builder.CurrentRoute);
        //}
    }
}
