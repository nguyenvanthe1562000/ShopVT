using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20AnnouncementModel 
     {
       	
	public int ID { set; get; }
	public string title { set; get; }
	public string content { set; get; }
	public bool HasRead { set; get; }
	public string UserCode { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


