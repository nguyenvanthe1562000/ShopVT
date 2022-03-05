using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B10ProductTagModel 
     {
       	
	public int ID { set; get; }
	public string ProductCode { set; get; }
	public string TagId { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


