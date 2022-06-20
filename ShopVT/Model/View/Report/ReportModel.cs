using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.View
{
    public class usp_banchay
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
    public class usp_ton
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool WarningQty { get; set; }
        public int Quantity { get; set; }

    }
    public class usp_Nhap
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal TotalAmount { get; set; }
        public int Quantity { get; set; }
    }
}
