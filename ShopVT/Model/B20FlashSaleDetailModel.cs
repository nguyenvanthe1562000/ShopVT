using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20FlashSaleDetailModel 
     {
       	
	public int ID { set; get; }
	public string Flashsalecode { set; get; }
	public bool ApplyForAll { set; get; }
	public string ProductCategoryCode { set; get; }
	public string ProductCode { set; get; }
	public decimal DiscountPercent { set; get; }
	public decimal UnitPrice { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


