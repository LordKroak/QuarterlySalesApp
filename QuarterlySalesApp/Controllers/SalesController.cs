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
    public class SalesController : Controller
    {
        public EmployeeContext Context { get; set; }
        public SalesController(EmployeeContext context)
        {
            Context = context;
        }
        public IActionResult Add()
        {
            //populate viewbag sales with a list of sales
            ViewBag.Sales = Context.Sales.ToList();
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
