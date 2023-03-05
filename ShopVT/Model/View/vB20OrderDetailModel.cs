using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class vB20OrderDetailModel
    {

         public int Id { set; get; }
    public string OrderCode { set; get; }
    public string Stt { set; get; }
    public string ProductCode { set; get; }
    public int Quantity { set; get; }
    public decimal UnitPrice { set; get; }
    public decimal Amount { set; get; }
    public bool IsActive { set; get; }
    public int CreatedBy { set; get; }
    public DateTime CreatedAt { set; get; }
    public int ModifiedBy { set; get; }
    public DateTime ModifiedAt { set; get; }
    public decimal UnitCost { set; get; }
    public decimal Quantity9 { set; get; }
    public decimal Amount2 { set; get; }
    public decimal Amount3 { set; get; }
    public string ProductName { set; get; }
    public string Image { set; get; }


    }
}



