using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class SalesUnitOfWork : ISalesUnitOfWork
    {
        private EmployeeContext Context { get; set; }
        public SalesUnitOfWork(EmployeeContext context) => context = Context;

        private Repository<Sales> salesData;
        public Repository<Sales> Sales
        {
            get
            {
                if (salesData == null)
                {
                    salesData = new Repository<Sales>(Context);
                }
                return salesData;
            }
        }

        private Repository<Employee> employeeData;
        public Repository<Employee> Employees
        {
            get
            {
                if (employeeData == null)
                {
                    employeeData = new Repository<Employee>(Context);
                }
                return employeeData;
            }
        }

        public void Save() => Context.SaveChanges();
    }
}
