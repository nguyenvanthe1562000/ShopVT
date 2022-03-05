using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B10CustomerModel 
     {

        public int ID { set; get; }
        public string Name { set; get; }
        public string email { set; get; }
        public string phone { set; get; }
        public int gender { set; get; }
        public DateTime BirthDate { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public string Code { set; get; }
        public string FullName { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }
        public List<B10CustomerAddressModel> B10CustomerAddress_Json { get; set; }
    }
}


