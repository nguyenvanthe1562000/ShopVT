using System;
using System.Collections.Generic;
using System.Text;
using Model.Model;
namespace ViewModel.Common
{
    public class PagedResult<T> 
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int PageCount { get; set; }
      

        public List<T> Items { set; get; }
    }
}