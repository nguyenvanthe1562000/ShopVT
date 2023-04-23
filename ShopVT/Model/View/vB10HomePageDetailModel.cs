using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class vB10HomePageDetailModel
    {

        public int Id { set; get; }
        public string Stt { set; get; }
        public string ProductCode { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public string ProductName { set; get; }
        public decimal StandardPriceRetail { set; get; }
        public string Unit { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal DiscountRate { set; get; }

    }
}



