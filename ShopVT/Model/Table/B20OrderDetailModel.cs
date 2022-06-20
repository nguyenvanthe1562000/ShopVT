using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20OrderDetailModel 
     {
       	
	public int ID { set; get; }
	public string OrderCode { set; get; }
	public string ProductCode { set; get; }
	public int Quantity { set; get; }
	public decimal UnitPrice { set; get; }
	public decimal Amount { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


