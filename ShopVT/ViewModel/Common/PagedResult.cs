using System;
using System.Collections.Generic;
using System.Text;
using Model.Model;
namespace ViewModel.Common
{
    public class PagedResult<T> : PagedResultBase
    {
        public List<T> Items { set; get; }
    }
}