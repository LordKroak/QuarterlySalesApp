using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace QuarterlySalesApp.Models
{
    public class SalesGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Year { get; set; } = DefaultFilter;
        public string Quarter { get; set; } = DefaultFilter;
        public string Employee { get; set; } = DefaultFilter;
    }
}
