using Model.Enums;
using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20ChatsModel 
     {
       	
	public int ID { set; get; }
	public string Name { set; get; }
	public ChatType Type { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	

     }
}


