using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20ProductReturnModel 
     {
       	
	public int ID { set; get; }
	public string OrderCode { set; get; }
	public string CustomerName { set; get; }
	public string CustomerAddress { set; get; }
	public string CustomerEmail { set; get; }
	public string CustomerMobile { set; get; }
	public int IdCardNo { set; get; }
	public string ProductCode { set; get; }
	public decimal ProductPrice { set; get; }
	public decimal Quantity { set; get; }
	public decimal Amount { set; get; }
	public string note { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


