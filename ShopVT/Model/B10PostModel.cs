using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B10PostModel 
     {
       	
	public int ID { set; get; }
	public string Name { set; get; }
	public string Alias { set; get; }
	public string PostCategoryCode { set; get; }
	public string Image { set; get; }
	public string Description { set; get; }
	public string Content { set; get; }
	public string MetaDescription { set; get; }
	public string MetaKeyword { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


