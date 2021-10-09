using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B00UserPermisionModel 
     {
       	
	public int ID { set; get; }
	public string userCode { set; get; }
	public int ActPermisionId { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


