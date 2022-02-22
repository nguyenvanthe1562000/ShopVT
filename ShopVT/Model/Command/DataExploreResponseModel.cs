using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Command
{
    public class DataExploreGroupResponseModel
    {
        public int Id { get; set; }
        public int Parentid { get; set; }
        public string Caption { get; set; }
    }
  
    public class DataExplorePagingDataResponseModel
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int PageCount { get; set; }

        public string ListObj { get; set; }
    }
}
