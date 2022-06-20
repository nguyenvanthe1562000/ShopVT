using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class vB20AccDocProductDetailModel
    {

        public int Id { set; get; }
        public string Stt { set; get; }
        public string ProductCode { set; get; }
        public string ProductName { set; get; }
        public string Unit { set; get; }
        public int Quantity { set; get; }
        public decimal UnitPrice { set; get; }
        public decimal Amount { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public string ImagePath { set; get; }
        public string Note { set; get; }


    }
}



