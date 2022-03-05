using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B10CustomerAddressModel 
     {
       	
	public int ID { set; get; }
	public int CustomerId { set; get; }
	public int CustomerAccountId { set; get; }
	public string Address { set; get; }
	public string Name { set; get; }
	public string Phone { set; get; }
	public string Note { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


