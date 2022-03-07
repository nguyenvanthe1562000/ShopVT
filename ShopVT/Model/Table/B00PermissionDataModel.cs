using Model.Auth;
using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class B00PermissionDataModel
    {

        public int Id { set; get; }
        public int UserId { set; get; }
        public int CommandId { set; get; }
        public string Description { set; get; }
        public PermissionData Permission { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }


    }
}


