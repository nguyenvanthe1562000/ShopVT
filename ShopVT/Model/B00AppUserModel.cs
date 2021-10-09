using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B00AppUserModel 
     {
       	
	public int ID { set; get; }
	public string code { set; get; }
	public string username { set; get; }
	public string PassWord { set; get; }
	public string FullName { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	public string EmployeeCode { set; get; }
	

     }
}


