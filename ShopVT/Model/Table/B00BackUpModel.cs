using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B00BackUpModel 
     {
        
    public int Id { set; get; }
    public string FileName { set; get; }
    public decimal Size { set; get; }
    public DateTime DocDate { set; get; }
    public bool IsActive { set; get; }
    public int CreatedBy { set; get; }
    public DateTime CreatedAt { set; get; }
    public int ModifiedBy { set; get; }
    public DateTime ModifiedAt { set; get; }
    public string EmployeeCode { set; get; }
    

     }
}



