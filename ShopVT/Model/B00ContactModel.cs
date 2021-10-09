using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B00ContactModel 
     {
       	
	public int ID { set; get; }
	public string code { set; get; }
	public string Name { set; get; }
	public string Email { set; get; }
	public string PhoneNumber { set; get; }
	public string Facebook { set; get; }
	public string address { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


