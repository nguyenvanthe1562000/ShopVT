﻿using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20PromotionModel 
     {
       	
	public int ID { set; get; }
	public bool IsGroup { set; get; }
	public int ParentId { set; get; }
	public string code { set; get; }
	public DateTime FromDate { set; get; }
	public DateTime ToDate { set; get; }
	public string ProductCode { set; get; }
	public decimal Price { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


