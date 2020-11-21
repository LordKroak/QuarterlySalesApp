using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace QuarterlySalesApp.Models
{
    public class SalesGridBuilder
    {
        private const string RouteKey = "currentroute";

        protected RouteDictionary routes { get; set; }
        private ISession session { get; set; }
        //this constructor used when just need to get route data from the session
        public SalesGridBuilder(ISession sess)
        {
            session = sess;
            routes = session.GetObject<RouteDictionary>(RouteKey) ?? new RouteDictionary();
        }

        //this constructor used when need to store paging-sorting route segments
        public SalesGridBuilder(ISession sess, GridDTO values, string defaultSortField)
        {
            session = sess;
            routes = new RouteDictionary();
            routes.PageNumber = values.PageNumber;
            routes.PageSize = values.PageSize;
            routes.SortField = values.SortField;
            routes.SortDirection = values.SortDirection;

            SaveRouteSegments();
        }

        public void SaveRouteSegments() => session.SetObject<RouteDictionary>(RouteKey, routes);
        
        public int GetTotalPages(int count)
        {
            int size = routes.PageSize;
            return (count + size - 1) / size;
        }

        //filter flags
        string def = SalesGridDTO.DefaultFilter;
        public bool IsFilterByYear => routes.YearFilter != def;
        public bool isFilterByQuarter => routes.QuarterFilter != def;
        public bool isFilterByEmployee => routes.EmployeeFilter != def;
        //sort flags
        public bool IsSortByYear => routes.SortField.EqualsNoCase(nameof(Sales.Year));
        public bool IsSortByQuarter => routes.SortField.EqualsNoCase(nameof(Sales.Quarter));
        public bool IsSortByEmployee => routes.SortField.EqualsNoCase(nameof(Sales.Employee));
        public bool IsSortByAmount => routes.SortField.EqualsNoCase(nameof(Sales.SalesAmount));
        public RouteDictionary CurrentRoute => routes;
    }
}
