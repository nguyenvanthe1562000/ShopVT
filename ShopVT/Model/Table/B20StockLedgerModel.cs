using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B20StockLedgerModel 
     {
       	
	public int ID { set; get; }
	public bool DocGroup { set; get; }
	public DateTime DocDate { set; get; }
	public string Description { set; get; }
	public string Unit { set; get; }
	public decimal Quantity { set; get; }
	public decimal UnitCost { set; get; }
	public decimal OriginalUnitCost { set; get; }
	public decimal Warranty { set; get; }
	public decimal Unitprice { set; get; }
	public decimal Amount { set; get; }
	public decimal OriginalAmount { set; get; }
	public decimal ExpenseAmount { set; get; }
	public decimal transportationcosts { set; get; }
	public bool IsActive { set; get; }
	public int CreatedBy { set; get; }
	public DateTime CreatedAt { set; get; }
	public int ModifiedBy { set; get; }
	public DateTime ModifiedAt { set; get; }
	

     }
}


