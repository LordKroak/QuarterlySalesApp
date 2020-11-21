using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuarterlySalesApp.Models
{
    public class SalesQuery : QueryOptions<Sales>
    {
        public void SortFilter(SalesGridBuilder builder)
        {
            if (builder.IsFilterByYear)
            {
                Where = b => b.Year == builder.CurrentRoute.YearFilter.ToInt();
            }
            if (builder.isFilterByQuarter)
            {
                Where = b => b.Quarter == builder.CurrentRoute.QuarterFilter.ToInt();
            }
            if (builder.isFilterByEmployee)
            {
                Where = b => b.EmployeeID == builder.CurrentRoute.EmployeeFilter.ToInt();
            }


            if (builder.IsSortByYear)
            {
                OrderBy = b => b.Year;
            }
            else if (builder.IsSortByQuarter)
            {
                OrderBy = b => b.Quarter;
            }
            else if (builder.IsSortByEmployee)
            {
                OrderBy = b => b.Employee.FirstName;
            }
            else
            {
                OrderBy = b => b.SalesAmount;
            }

        }
    }
}
