using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySalesApp.Models;

namespace QuarterlySalesApp.Models
{
    public class ISalesUnitOfWork
    {
        Repository<Sales> Sales { get; }
        Repository<Employee> Employees { get; }
    }
}
