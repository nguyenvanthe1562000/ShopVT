using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B10SupplierModel 
     {
        public int Id { set; get; }
        public int ParentId { set; get; }
        public bool IsGroup { set; get; }
        public string Code { set; get; }
        public string FullName { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public int Gender { set; get; }
        public int SupplierType { set; get; }
        public string ProductCategoryCode { set; get; }
        public string Address { set; get; }
        public string BankAccount { set; get; }
        public string BankName { set; get; }
        public DateTime BirthDate { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
     }
}



