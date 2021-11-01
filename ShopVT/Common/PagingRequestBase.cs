using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class PagingRequestBase
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }
        public string OrderBy  { get ; set; } = "id";

    }
}