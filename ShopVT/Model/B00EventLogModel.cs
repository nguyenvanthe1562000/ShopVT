using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B00EventLogModel 
     {
       	
	public int ID { set; get; }
	public string SessionId { set; get; }
	public string LastValue { set; get; }
	public string Command { set; get; }
	public string NewValue { set; get; }
	public string TableName { set; get; }
	public DateTime LastWriteAt { set; get; }
	public int LastWriteBy { set; get; }
	public int RowId { set; get; }
	public string ColumnName { set; get; }
	

     }
}


