﻿using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20OpenInventoryModel 
     {
       	
	public int ID { set; get; }
	public bool IsGroup { set; get; }
	public int ParentId { set; get; }
	public string ItemCode { set; get; }
	public string Year { set; get; }
	public string Month { set; get; }
	public DateTime DocDate { set; get; }
	public decimal OriginalUnitCost { set; get; }
	public decimal UnitCost { set; get; }
	public string Unit { set; get; }
	public int Quantity { set; get; }
	public decimal rate { set; get; }
	public decimal OriginalExpenseAmount { set; get; }
	public decimal ExpenseAmount { set; get; }
	public decimal Amount { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


