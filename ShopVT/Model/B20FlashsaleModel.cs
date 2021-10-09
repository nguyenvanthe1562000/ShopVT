using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20FlashsaleModel 
     {
       	
	public int ID { set; get; }
	public string code { set; get; }
	public DateTime FromDate { set; get; }
	public DateTime ToDate { set; get; }
	public string Name { set; get; }
	public string Description { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


