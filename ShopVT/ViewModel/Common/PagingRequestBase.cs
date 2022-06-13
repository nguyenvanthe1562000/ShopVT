using Model.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public  class PagingRequestBase
    {

        public  int PageIndex { get; set; }
        public  int PageSize { get; set; }
        public  string OrderBy { get; set; } = "id";
        public  bool OrderDesc { get; set; }
       


    }
    public class PagingRequest : PagingRequestBase
    {
      
        public string FilterColumn { get ; set; }
        public FilterType FilterType { get ; set; }
        public string FilterValue { get ; set; }
        public int ParentId { get; set; }
        public bool DataIsActive { get; set; }
    }
}