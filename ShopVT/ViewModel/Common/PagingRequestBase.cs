using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.Common
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        public string OrderBy { get; set; } 
        public string OrderDesc { get; set; }

        public void Validation()
        {
            if (PageIndex < 1)
            {
                PageIndex = 1;
            }
            if (PageSize > 200)
            {
                PageSize = 200;
            }
            if (PageSize < 10)
            {
                PageSize = 10;
            }
            if(string.IsNullOrEmpty( OrderBy))
            {
                OrderBy = "Id";
            }
            if (string.IsNullOrEmpty(OrderDesc))
            {
                OrderDesc = "ASC";
            }
        }
    }
}