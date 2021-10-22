using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopVT.Models
{
    public class Roles
    {
        public string Function  { get; set; }
        public string CanRead   { get; set; }
        public string CanCreate { get; set; }
        public string CanUpdate { get; set; }
        public string CanDelete { get; set; }
        public string CanReport { get; set; }
    }
}
