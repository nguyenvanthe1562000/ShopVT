using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B00CommandLogModel 
     {
       	
	public int Id { set; get; }
	public string Command { set; get; }
	public string UserIp { set; get; }
	public string AppUserCode { set; get; }
	public DateTime LastWriteAt { set; get; }
	

     }
}


