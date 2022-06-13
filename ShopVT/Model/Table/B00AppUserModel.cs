using System;
using System.Collections.Generic;
namespace Model.Model
{
     public class B00AppUserModel 
     {
        public int Id { set; get; }
        public bool IsGroup { set; get; }
        public int ParentId { set; get; }
        public string Code { set; get; }
        public string Username { set; get; }
        public string PassWord { set; get; }
        public string FullName { set; get; }
        public bool IsActive { set; get; }
        public int CreatedBy { set; get; }
        public DateTime CreatedAt { set; get; }
        public int ModifiedBy { set; get; }
        public DateTime ModifiedAt { set; get; }
        public string EmployeeCode { set; get; }
        public List<B00PermissionFunctionModel> B00PermissionFunction_Json { set; get; }
		public List<B00PermissionDataModel> B00PermissionData_Json { set; get; }

     }
}


