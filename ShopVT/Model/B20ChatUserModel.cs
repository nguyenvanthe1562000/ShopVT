using Model.Enums;
using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20ChatUserModel 
     {
       	
	public int ID { set; get; }
	public string UserCode { set; get; }
	public string customerCode { set; get; }
	public string IpAddress { set; get; }
	public int ChatId { set; get; }
	public UserRole Role { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int UserId { set; get; }
	

     }
}


