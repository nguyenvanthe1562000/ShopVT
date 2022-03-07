using Model.Auth;
using System;
using System.Collections.Generic;
namespace Model.Model
{
    public class B00PermissionFunctionModel
    {

        public int Id { set; get; }
        public int UserId { set; get; }
        public string Description { set; get; }
        public PermissionFunction Permision { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }


    }
}


