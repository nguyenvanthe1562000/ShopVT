using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class B10CustomerAccountModel
    {
        public int ID { set; get; }
        public string username { set; get; }
        public string PassWord { set; get; }
        public string Email { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public B10CustomerModel B10Customer_Json { set; get; }
        public List<B10CustomerAddressModel> B10CustomerAddress_Json { set; get; }

    }
}


