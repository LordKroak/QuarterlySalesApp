﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace QuarterlySalesApp.Models
{
    public class RouteDictionary : Dictionary<string, string>
    {
        //paging and sorting properties and methods here
        public int PageNumber
        {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }
        public int PageSize
        {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }
        public string SortField
        {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }
        public string SortDirection
        {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }
        //Filters
        public string YearFilter
        {
            get => Get(nameof(SalesGridDTO.Year));
            set => this[nameof(SalesGridDTO.Year)] = value;
        }

        public string QuarterFilter
        {
            get => Get(nameof(SalesGridDTO.Quarter));
            set => this[nameof(SalesGridDTO.Quarter)] = value;
        }

        public string EmployeeFilter
        {
            get
            {
                string employeeName = Get(nameof(SalesGridDTO.Employee));
                int hSearch = employeeName?.IndexOf('-')??-1; //gives us the position of the '-' //if our employeeName is null, give a -1. Otherwise give position.
                if(hSearch == -1)
                {
                    return employeeName;
                }
                else
                {
                    return employeeName.Substring(0, hSearch); //gets from start of string, to the '-' but does not include the '-'.
                }
            }
            set => this[nameof(SalesGridDTO.Employee)] = value;
        }
        public void ClearFilters() => YearFilter = EmployeeFilter = QuarterFilter = SalesGridDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public void SetSortAndDirection(string fieldName, RouteDictionary current)
        {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) && current.SortDirection == "asc")
            {
                this[nameof(GridDTO.SortDirection)] = "desc";
            }
            else
            {
                this[nameof(GridDTO.SortDirection)] = "asc";
            }
        }

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys)
            {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
