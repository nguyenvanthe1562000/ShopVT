using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common
{
    public class DataExploreRequestModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Table { get; set; }
        public string? ParentId { get; set; }
        public bool IsActive { get; set; }
        public string OrderBy { get; set; }
        public bool OrderDesc { get; set; }

      
    }
   


}
