using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B10ProductModel 
     {
       	
	public int ID { set; get; }
	public string code				{ set; get; }
	public string Name				{ set; get; }
	public string Alias				{ set; get; }
	public string ProductCategoryCode { set; get; }
	public decimal UnitCost			 { set; get; }
	public decimal UnitPrice			{ set; get; }
	public int		Warranty			 {			 set; get; }
	public string Description { set; get; }
	public string Content { set; get; }
	public string Information { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


