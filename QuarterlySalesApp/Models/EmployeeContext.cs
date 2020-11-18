using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class EmployeeContext : DbContext 
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sales> Sales { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeID = 1,
                    FirstName = "Ada",
                    LastName = "Lovelace",
                    DateOfBirth = new DateTime(1956, 12, 10),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerID = 0  // has no manager
                },
                new Employee
                {
                    EmployeeID = 2,
                    FirstName = "Luigi",
                    LastName = "Verminelli",
                    DateOfBirth = new DateTime(1977, 3, 27),
                    DateOfHire = new DateTime(1998, 1, 1),
                    ManagerID = 1
                },
                new Employee
                {
                    EmployeeID = 3,
                    FirstName = "Carl",
                    LastName = "Wheezer",
                    DateOfBirth = new DateTime(1966, 11, 5),
                    DateOfHire = new DateTime(1995, 1, 1),
                    ManagerID = 1
                }
            );

            modelbuilder.Entity<Sales>().HasData(
                new Sales
                {
                    SalesID = 1,
                    Quarter = 4,
                    Year = 2019,
                    SalesAmount = 20100,
                    EmployeeID = 2
                },
                new Sales
                {
                    SalesID = 2,
                    Quarter = 1,
                    Year = 2020,
                    SalesAmount = 31211,
                    EmployeeID = 2
                },
                new Sales
                {
                    SalesID = 3,
                    Quarter = 2,
                    Year = 202020,
                    SalesAmount = 42322,
                    EmployeeID = 3
                }
            );
                
        }
    }
}
