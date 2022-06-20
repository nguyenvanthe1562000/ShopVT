using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.catalog.AccDoc
{
    public class ReportRequest
    {
        public DateTime DocDate1 { set; get; }
        public DateTime DocDate2 { set; get; }
        public string ItemCode { set; get; }
    }
}
